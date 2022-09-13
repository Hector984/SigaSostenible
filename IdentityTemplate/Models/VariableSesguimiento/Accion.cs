namespace IdentityTemplate.Models.VariableSesguimiento
{
    public class Accion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        #region Propiedades de navegacion
        public int LineaEstrategicaId { get; set; }
        public LineaEstrategica LineaEstrategica { get; set; }
        #endregion
    }
}
