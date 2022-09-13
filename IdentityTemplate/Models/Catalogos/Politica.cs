using IdentityTemplate.Models.Intermedios;
using IdentityTemplate.Models.VariablesDeSeguimiento;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.Models.Catalogos
{
    public class Politica
    {
        public int PoliticaId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Nombre de la Política o Acción")]
        [StringLength(maximumLength: 100, ErrorMessage = "El valor máximo son {1} caracteres")]
        public string NombrePolitica { get; set; }

        public IEnumerable<PoliticaUsuario> PoliticaUsuario { get; set; }

        public IEnumerable<EjeTematico> EjesTematicos { get; set; }
    }

}
