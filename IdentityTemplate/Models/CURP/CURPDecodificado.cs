namespace IdentityTemplate.Models.CURP
{
    public class CURPDecodificado
    {
        public string codigo { get; set; }
        public List<Registro> registros { get; set; }
        public string mensaje { get; set; }
    }

    public class Registro
    {
        public string fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string entidad { get; set; }
        public string claveEntidad { get; set; }
        public DatosDocProbatorio datosDocProbatorio { get; set; }
        public int docProbatorio { get; set; }
        public string statusCurp { get; set; }
        public string parametro { get; set; }
        public string nombres { get; set; }
        public string nacionalidad { get; set; }
        public string primerApellido { get; set; }
        public string curp { get; set; }
        public string segundoApellido { get; set; }
    }

    public class DatosDocProbatorio
    {
        public string foja { get; set; }
        public string tomo { get; set; }
        public string libro { get; set; }
        public string numActa { get; set; }
        public string claveEntidadRegistro { get; set; }
        public string entidadRegistro { get; set; }
        public string municipioRegistro { get; set; }
        public string claveMunicipioRegistro { get; set; }
        public string anioReg { get; set; }
    }
}
