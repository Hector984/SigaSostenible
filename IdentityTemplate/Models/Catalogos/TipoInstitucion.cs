namespace IdentityTemplate.Models.Catalogs
{
    public class TipoInstitucion
    {
        public int TipoInstitucionId { get; set; }
        public Institucion Institucion { get; set; }

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
