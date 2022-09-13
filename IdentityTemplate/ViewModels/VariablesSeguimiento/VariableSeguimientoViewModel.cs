using IdentityTemplate.Models.Catalogos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels.VariablesSeguimiento
{
    public class VariableSeguimientoViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Ingresa la variable de seguimiento")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Cantidad de la Meta")]
        public int Meta { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Unidad de la Meta")]
        public int UnidadMetaId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Inicio de acciones")]
        [StringLength(maximumLength: 4, MinimumLength = 4)]
        public string InicioAcciones { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(maximumLength: 4, MinimumLength = 4)]
        [Display(Name = "Fin de acciones")]
        public string FinAcciones { get; set; }
        public IEnumerable<SelectListItem> UnidadesMeta { get; set; }
    }
}
