using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.ViewModels.VariablesSeguimiento
{
    public class EjeTematicoViewModel : PoliticaViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Descripcion del Eje Temático")]
        public override string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Política")]
        public int PoliticaId { get; set; }
        public IEnumerable<SelectListItem> Politicas { get; set; }


    }
}
