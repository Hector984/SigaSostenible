using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.Models.Cuenta
{
    public class LoginUser
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [EmailAddress]
        [Display(Name ="Correo")]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "La {0} es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool Recordarme { get; set; } = false;
    }
}
