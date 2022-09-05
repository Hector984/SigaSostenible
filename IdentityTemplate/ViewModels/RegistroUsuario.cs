using IdentityTemplate.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels
{
    public class RegistroUsuario : ApplicationUser
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Correo Laboral *")]
        [Remote(action: "VerificarExisteCorreoLaboralUsuario", controller: "Cuenta")]
        [EmailAddress(ErrorMessage = "Ingresa un correo con formato válido.")]
        public string CorreoLaboral { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Téléfono Laboral *")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"(\\(\d{3}\\)[●-]?|\d{3}[●-]?)?\d{3}[●-]?\d{4}", ErrorMessage = "El formato no es válido")]
        public string TelefonoLaboral { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "La contraseña debe contener mínimo {1} caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña *")]
        public string Contrasenia { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contrasenia", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContrasenia { get; set; }
        public IEnumerable<SelectListItem> TipoInstituciones { get; set; }
        public IEnumerable<SelectListItem> NivelesDeSeguimiento { get; set; }
        public IEnumerable<SelectListItem> NivelesDeResponsabilidad { get; set; }
        
    }
}
