using IdentityTemplate.Areas.Identity.Data;
using IdentityTemplate.Models.Catalogos;

namespace IdentityTemplate.Models.Intermedios
{
    public class PoliticaUsuario
    {
        public string UsuarioId { get; set; }
        public int PoliticaId { get; set; }
        public ApplicationUser Usuario { get; set; }
        public Politica Politica { get; set; }
    }
}
