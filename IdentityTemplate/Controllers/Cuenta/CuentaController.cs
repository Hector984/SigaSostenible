using IdentityTemplate.Areas.Identity.Data;
using IdentityTemplate.Areas.Identity.Pages.Account;
using IdentityTemplate.Data;
using IdentityTemplate.Models.Catalogos;
using IdentityTemplate.Models.Cuenta;
using IdentityTemplate.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text;
using IdentityTemplate.Helpers;
using IdentityTemplate.Servicios;
using IdentityTemplate.Models.CURP;
using IdentityTemplate.Models.Intermedios;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace IdentityTemplate.Controllers.Cuenta
{
    
    public class CuentaController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IServicioCorreo _servicioCorreo;
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly ICatalogosHelpers _catalogosHelpers;
        private readonly IConfiguration _configuration;
        private readonly IServicioCURP _servicioCURP;
        private readonly ILogger<LoginModel> _logger;

        public CuentaController(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, 
            UserManager<ApplicationUser> userManager, 
            ApplicationDBContext applicationDBContext, ICatalogosHelpers catalogosHelpers, 
            IConfiguration configuration, IServicioCURP servicioCURP,
            IUserStore<ApplicationUser> userStore, IServicioCorreo servicioCorreo)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _applicationDBContext = applicationDBContext;
            _catalogosHelpers = catalogosHelpers;
            _configuration = configuration;
            _servicioCURP = servicioCURP;
            _userStore = userStore;
            _servicioCorreo = servicioCorreo;
        }

        #region Registro

        [HttpGet]
        //[Authorize(Roles = "Administrator Nacional")]
        public async Task<IActionResult> Registro()
        {
            //Recuperamos las instituciones
            var tipoDeInstituciones = await _catalogosHelpers.ObtenerTipoInstituciones();
            //Recuperamos el nivel de seguimiento
            var nivelesDeSeguimiento = await _catalogosHelpers.ObtenerNivelesDeSeguimiento();
            //Recuperamos el nivel de responsabilidad
            var nivelesDeResponsabilidad = await _catalogosHelpers.ObtenerNivelesDeresponsabilidad();
            //Recuperamos las politicas existentes
            var politicas = await _catalogosHelpers.ObtenerPoliticas();

            var modeloRegistroUsuario = new RegistroUsuario()
            {
                TipoInstituciones = tipoDeInstituciones,
                NivelesDeResponsabilidad = nivelesDeResponsabilidad,
                NivelesDeSeguimiento = nivelesDeSeguimiento,
                Politicas = politicas

            };

            return View(modeloRegistroUsuario);
        }
        
        [HttpPost]
        //[Authorize(Roles = "Administrator Nacional")]
        public async Task<IActionResult> RegistrarUsuario(RegistroUsuario modeloUsuario)
        {

            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError(string.Empty, "Datos inválidos.");

                return View("Registro", modeloUsuario);
            }

            modeloUsuario.Email = modeloUsuario.CorreoLaboral;
            modeloUsuario.NormalizedEmail = modeloUsuario.CorreoLaboral.ToUpper();
            modeloUsuario.NormalizedUserName = modeloUsuario.UserName.ToUpper();
            modeloUsuario.PhoneNumber = modeloUsuario.TelefonoLaboral;

            //Creamos el usuario
            var resultado = await _userManager.CreateAsync(modeloUsuario, modeloUsuario.Contrasenia);
           
            if (resultado.Succeeded)
            {

                _logger.LogInformation("Nuevo usuario creado.");

                //Asignamos la politica o accion
                var usuario = await _userManager.FindByEmailAsync(modeloUsuario.Email);

                var politicaUsuario = new PoliticaUsuario()
                {
                    PoliticaId = modeloUsuario.PoliticaId,
                    UsuarioId = usuario.Id
                };

                var politicaAsignada = _applicationDBContext.PoliticaUsuario.Add(politicaUsuario);

                await _applicationDBContext.SaveChangesAsync();

                //Asignamos el token de confirmacion
                var tokenDeConfirmacion = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);

                var linkDeConfirmacion = Url.ActionLink(action: "ConfirmarCorreo", controller: "Cuenta",
                    values: new { usuarioId = usuario.Id, token = tokenDeConfirmacion });

                //Enviar el correo para confirmar cuenta
               
                await _servicioCorreo.EnviarCorreoAsync(usuario.Email, "Confirmación de cuenta en SigaSostenible.",
                    $"<p>Tu contraseña asignada es {modeloUsuario.Contrasenia}</p> </br></br> <p>Da click en el siguiente enlace para verificar tu cuenta {linkDeConfirmacion}</p>");

                ViewBag.Nombre = usuario.Nombre;
                ViewBag.PrimerApellido = usuario.PrimerApellido;
                ViewBag.SegundoApellido = usuario.SegundoApellido;
                ViewBag.Correo = usuario.Email;

                return View("RegistroExitoso");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View("Registro", modeloUsuario);
            }
            
        }

        [HttpGet]
        public IActionResult RegistroExitoso()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LlenarNombrePorCURP([FromBody] CURP curp)
        {
            var datos = await _servicioCURP.ObtenerDatos(curp.curp);


            return Ok(datos);
        }
        #endregion

        #region Inicio sesion
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser loginUser, string returnUrl = null)
        {

            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Datos inválidos. Fallo al iniciar sesión.");
                
                return View();
            }

            returnUrl ??= "/Home/index";

            var usuario = await _userManager.FindByEmailAsync(loginUser.Email);

            //Verificamos que la cuenta este confirmada
            if(usuario is not null && await _userManager.CheckPasswordAsync(usuario, loginUser.Password))
            {
                if (usuario.EmailConfirmed is false)
                {
                   
                    ModelState.AddModelError(string.Empty, "Cuenta no confirmada. Te hemos envíado un correo para confirmar tu cuenta.");
                    
                    return View();

                };
            }

            var respuesta = await _signInManager.PasswordSignInAsync(usuario.UserName, loginUser.Password, false, lockoutOnFailure: false);

            if(respuesta.Succeeded)
            {
                string mensajeLog = String.Format("El usuario {0} ha iniciado sesión", usuario.NormalizedUserName);

                _logger.LogInformation(mensajeLog);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido.");

            return View();
        }

        #endregion

        #region Confirmar Cuenta
        [HttpGet]
        public async Task<IActionResult> ConfirmarCorreo(string usuarioId, string token)
        {

            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (usuario is not null)
            {
                var resultado = await _userManager.ConfirmEmailAsync(usuario, token);

                if (resultado.Succeeded)
                {
                    return View();

                }
            }

            ViewBag.MensajeError = "No pudimos confirmar la cuenta para este usuario";

            return View("Error", "Home");
        }

        #endregion

        #region Cambiar Contraseña
        [HttpGet]
        //[Authorize]
        public IActionResult ContraseñaOlvidada()
        {
            //var usuario = await _userManager.GetUserAsync(HttpContext.User);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContraseñaOlvidada(ContraseñaOlvidadaViewModel contraseñaOlvidadaViewModel)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }

            var usuario = await _userManager.FindByEmailAsync(contraseñaOlvidadaViewModel.Correo);

            if (usuario is null || !(await _userManager.IsEmailConfirmedAsync(usuario)))
            {
                ViewBag.Error = "El usuario es inválido o la cuenta no está confirmada.";

                return View();
            }

            //Asignamos el token de confirmacion
            var tokenDeConfirmacion = await _userManager.GeneratePasswordResetTokenAsync(usuario);

            var linkDeConfirmacion = Url.ActionLink(action: "ReestablecerContrasenia", controller: "Cuenta",
                values: new { usuarioId = usuario.Id, token = tokenDeConfirmacion });

            //Enviar el correo para reestablecer contraseña
            try
            {
                await _servicioCorreo.EnviarCorreoAsync(usuario.Email, "Reestablecer la contrasenia.",
                $"Da click en el siguiente enlace para reestablecer tu contraseña {linkDeConfirmacion}");

                return RedirectToAction("ConfirmacionContraseñaOlvidada");

            }
            catch(Exception ex)
            {
                string mensajeLog = String.Format("No pudimos enviar el correo para reestablecer la contraseña");

                _logger.LogInformation(mensajeLog);

                _logger.LogInformation(ex.Message);
            }

            ViewBag.MensajeError = "No pudimos enviar el correo para reestablecer la contraseña";

            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult ConfirmacionContraseñaOlvidada()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ReestablecerContrasenia(string usuarioId, string token)
        {

            var usuario = await _userManager.FindByIdAsync(usuarioId);

            //Si el usuario no se valida nos manda a la pantalla de error
            if(usuario is null)
            {
                string mensajeLog = String.Format("El usuario no puede reestablecer su contraseña porque no es valido.");

                _logger.LogInformation(mensajeLog);

                return RedirectToAction("Error", "Home");
            }

            var modelo = new CambiarContraseniaViewModel()
            {
                usuarioId = usuarioId,
                token = token
            };

            return View(modelo);
        }

        [HttpGet]
        public IActionResult ConfirmacionReestablecerContraseña()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmacionReestablecerContraseña(CambiarContraseniaViewModel cambiarContraseniaViewModel)
        {

            if(!ModelState.IsValid)
            {
                return RedirectToAction("ReestablecerContrasenia", cambiarContraseniaViewModel);
            }

            var usuario = await _userManager.FindByIdAsync(cambiarContraseniaViewModel.usuarioId);

            //Si el usuario no se valida nos manda a la pantalla de error
            if (usuario is null)
            {
                string mensajeLog = String.Format("El usuario no puede reestablecer su contraseña porque no es valido.");

                _logger.LogInformation(mensajeLog);

                return RedirectToAction("Error", "Home");
            }

            var resultado = await _userManager.ResetPasswordAsync(usuario, cambiarContraseniaViewModel.token, cambiarContraseniaViewModel.Contrasenia);

            if (resultado.Succeeded)
            {
                return RedirectToAction("ConfirmacionReestablecerContraseña");
            }

            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction("ReestablecerContraseña", cambiarContraseniaViewModel);
        }

            #endregion

        #region Acceso Denegado
        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }
        #endregion

        #region Verifcacion de campos
        [HttpGet]
        public async Task<IActionResult> VerificarExisteNombreUsuario(string UserName)
        {
            var yaExisteNombreDeUsuario = await _userManager.FindByNameAsync(UserName);

            if(yaExisteNombreDeUsuario != null)
            {
                return Json($"El nombre de usuario {UserName} ya existe.");
            }

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteCorreoLaboralUsuario(string CorreoLaboral)
        {
            var yaExisteCorreoDeUsuario = await _userManager.FindByEmailAsync(CorreoLaboral);

            if (yaExisteCorreoDeUsuario != null)
            {
                return Json($"El correo {CorreoLaboral} ya existe.");
            }

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteCorreoPersonalUsuario(string CorreoPersonal)
        {
            var yaExisteCorreoDeUsuario = await _userManager.Users
                                          .FirstOrDefaultAsync(u => u.CorreoPersonal.Equals(CorreoPersonal));

            if (yaExisteCorreoDeUsuario != null)
            {
                return Json($"El correo {CorreoPersonal} ya existe.");
            }

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteCURPUsuario(string CURP)
        {
            var yaExisteCURPDeUsuario = await _userManager.Users
                                          .FirstOrDefaultAsync(u => u.CURP.Equals(CURP));

            if (yaExisteCURPDeUsuario != null)
            {
                return Json($"Ya existe un usuario con ese CURP.");
            }

            return Json(true);
        }
        #endregion
    }
}
