namespace IdentityTemplate.Models.Catalogs
{
    public class PoliticaAccion
    {
        public PoliticaAccion()
        {
            PoliticaAccionId = new Guid().ToString();
        }

        public string PoliticaAccionId { get; set; }
        public string NombrePoliticaAccion { get; set; }
    }

}
