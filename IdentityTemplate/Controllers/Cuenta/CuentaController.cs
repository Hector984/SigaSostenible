﻿using IdentityTemplate.Areas.Identity.Data;
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

namespace IdentityTemplate.Controllers.Cuenta
{
    
    public class CuentaController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly ICatalogosHelpers _catalogosHelpers;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginModel> _logger;

        public CuentaController(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, 
            UserManager<ApplicationUser> userManager, ApplicationDBContext applicationDBContext, 
            ICatalogosHelpers catalogosHelpers, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _applicationDBContext = applicationDBContext;
            _catalogosHelpers = catalogosHelpers;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Registro()
        {
            //Recuperamos las instituciones
            var tipoDeInstituciones = await _catalogosHelpers.ObtenerTipoInstituciones();
            //Recuperamos el nivel de seguimiento
            var nivelesDeSeguimiento = await _catalogosHelpers.ObtenerNivelesDeSeguimiento();
            //Recuperamos el nivel de responsabilidad
            var nivelesDeResponsabilidad = await _catalogosHelpers.ObtenerNivelesDeresponsabilidad();

            var modeloRegistroUsuario = new RegistroUsuario()
            {
                TipoInstituciones = tipoDeInstituciones,
                NivelesDeResponsabilidad = nivelesDeResponsabilidad,
                NivelesDeSeguimiento = nivelesDeSeguimiento

            };

            ViewBag.Token = _configuration.GetSection("TokenBearerCURP").GetSection("Token").Value;
            ViewBag.URL = _configuration.GetSection("TokenBearerCURP").GetSection("URL").Value;

            return View(modeloRegistroUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(RegistroUsuario modeloUsuario)
        {

            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError(string.Empty, "Datos inválidos.");

                return RedirectToAction("Error", "Home");
            }


            //ApplicationUser usuario = new ApplicationUser()
            //{
            //    Nombre = modeloUsuario.Nombre,
            //};
            modeloUsuario.Email = modeloUsuario.CorreoLaboral;
            modeloUsuario.NormalizedEmail = modeloUsuario.CorreoLaboral.ToUpper();
            modeloUsuario.NormalizedUserName = modeloUsuario.UserName.ToUpper();
            modeloUsuario.PhoneNumber = modeloUsuario.TelefonoLaboral;

            //await _userStore.SetUserNameAsync(modeloUsuario, modeloUsuario.UserName, CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(modeloUsuario, modeloUsuario.Contrasenia);

            if (result.Succeeded)
            {
                _logger.LogInformation("Nuevo usuario creado.");

                //var userId = await _userManager.GetUserIdAsync(user);
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //var callbackUrl = Url.Page(
                //    "/Account/ConfirmEmail",
                //    pageHandler: null,
                //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                //    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //{
                //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //}
                //else
                //{
                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    return LocalRedirect(returnUrl);
                //}

                return RedirectToAction("RegistroExitoso", modeloUsuario);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View("Registro", modeloUsuario);
            }
            
        }

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

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, loginUser.Recordarme, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                ApplicationUser usuario = await _userManager.FindByEmailAsync(loginUser.Email);

                string mensajeLog = String.Format("El usuario {0} ha iniciado sesión", usuario.NormalizedUserName);
                _logger.LogInformation(mensajeLog);

                return LocalRedirect(returnUrl);

                //return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido.");
                return View();
            }

        }

        [HttpGet]
        public IActionResult RegistroExitoso(ApplicationUser modelo)
        {
            return View(modelo);
        }

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
