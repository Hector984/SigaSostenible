
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels.Catalogos
{
    public class PoliticaViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Nombre de la Política o Acción")]
        [StringLength(maximumLength: 100, ErrorMessage = "El valor máximo son {1} caracteres")]
        public string NombrePolitica { get; set; }
    }
}
