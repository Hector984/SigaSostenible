using IdentityTemplate.Areas.Identity.Data;
using IdentityTemplate.Areas.Identity.Pages.Account;
using IdentityTemplate.Models.Cuenta;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Controllers.Cuenta
{
    public class CuentaController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public CuentaController(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
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
    }
}
