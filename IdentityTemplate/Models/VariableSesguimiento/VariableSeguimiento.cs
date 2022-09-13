using IdentityTemplate.Models.Catalogos;

namespace IdentityTemplate.Models.VariablesDeSeguimiento
{
    public class VariableSeguimiento
    {
        public string Nombre { get; set; }
        public int Meta { get; set; }
        public UnidadMeta UnidadMeta { get; set; }
        public string  InicioAcciones { get; set; }
        public string FinAcciones { get; set; }
    }
}
