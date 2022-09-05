using IdentityTemplate.Areas.Identity.Data;

namespace IdentityTemplate.Models.Catalogos
{
    public class TipoInstitucion
    {
        public int TipoInstitucionId { get; set; }
        public string NombreDeInstitucion { get; set; }
        public virtual List<ApplicationUser> Usuario { get; set; }
    }

    public enum Institucion
    {
        Federal,
        Estatal,
        Municipal,
        Productores,
        Academia,
        SociedadCivil
    }
}
