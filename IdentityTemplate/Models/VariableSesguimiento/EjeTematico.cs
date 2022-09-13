using IdentityTemplate.Models.Catalogos;

namespace IdentityTemplate.Models.VariableSesguimiento
{
    public class EjeTematico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        #region Propiedades de navegacion

        public int PoliticaId { get; set; }
        public Politica Politica { get; set; }
        public IEnumerable<LineaEstrategica> LineasEstrategicas { get; set; }

        #endregion
    }
}
