using IdentityTemplate.Models.Intermedios;

namespace IdentityTemplate.Models.Catalogos
{
    public class Politica
    {
        public int PoliticaId { get; set; }
        public string NombrePolitica { get; set; }
        public IEnumerable<PoliticaUsuario> PoliticaUsuario { get; set; }
    }

}
