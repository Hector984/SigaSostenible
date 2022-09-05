using IdentityTemplate.Areas.Identity.Data;

namespace IdentityTemplate.Models.Catalogos
{
    public class NivelSeguimiento
    {
        public int NivelSeguimientoId { get; set; }
        public string NivelDeSeguimiento { get; set; }
        public virtual List<ApplicationUser> Usuario { get; set; }
    }

    public enum Niveles
    {
        Nacional,
        Estatal,
        Regional,
        Municipal,
        Local
    }
}
