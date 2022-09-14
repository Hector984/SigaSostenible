using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels.VariablesSeguimiento
{
    public class AccionViewModel : LineaEstrategicaViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Descripcion de la Acción")]
        [StringLength(maximumLength: 1000)]
        public override string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Línea Estrategíca")]
        public int LineaEstrategicaId { get; set; }
        public IEnumerable<SelectListItem> LineasEstrategicas { get; set; }
    }
}
