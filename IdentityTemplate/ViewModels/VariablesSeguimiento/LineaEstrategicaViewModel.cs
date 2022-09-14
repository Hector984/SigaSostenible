using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels.VariablesSeguimiento
{
    public class LineaEstrategicaViewModel : EjeTematicoViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Descripcion de la Línea Estrategíca")]
        public override string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Eje Temático")]
        public int EjeTematicoId { get; set; }
        public IEnumerable<SelectListItem> EjesTematicos { get; set; }
    }
}
