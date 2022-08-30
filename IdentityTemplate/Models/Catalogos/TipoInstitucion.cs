namespace IdentityTemplate.Models.Catalogs
{
    public class TipoInstitucion
    {
        public TipoInstitucion()
        {
            TipoInstitucionId = new Guid().ToString();
        }

        public string TipoInstitucionId { get; set; }
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
