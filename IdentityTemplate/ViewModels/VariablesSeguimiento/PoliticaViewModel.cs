using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels.VariablesSeguimiento
{
    public class PoliticaViewModel
    {

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Nombre de la Política o Acción")]
        [StringLength(maximumLength: 100, ErrorMessage = "El valor máximo son {1} caracteres")]
        public virtual string Nombre { get; set; }


    }
}
