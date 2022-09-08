using IdentityTemplate.Models.Cuenta;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels
{
    public class CambiarContraseniaViewModel
    {

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "La contraseña debe contener mínimo {1} caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña *")]
        public string Contrasenia { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contrasenia", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContrasenia { get; set; }
        public string usuarioId { get; set; }
        public string token { get; set; }

    }
}
