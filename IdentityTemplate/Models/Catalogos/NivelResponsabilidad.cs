using IdentityTemplate.Areas.Identity.Data;

namespace IdentityTemplate.Models.Catalogos
{
    public class NivelResponsabilidad
    {
        public int NivelResponsabilidadId { get; set; }
        public string NivelDeResponsabilidad { get; set; }
        public virtual List<ApplicationUser> Usuario { get; set; }
    }
}
