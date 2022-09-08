using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels
{
    public class ContraseñaOlvidadaViewModel
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [EmailAddress]
        public string Correo { get; set; }
    }
}
