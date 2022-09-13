﻿using IdentityTemplate.Models.Catalogos;

namespace IdentityTemplate.Models.VariableSesguimiento
{
    public class LineaEstrategica
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        #region Propiedades de nevegacion
        public int PoliticaId { get; set; }
        public Politica Politica { get; set; }
        #endregion
    }
}