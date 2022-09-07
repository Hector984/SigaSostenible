using IdentityTemplate.Models.CURP;
using System.Text.Json;

namespace IdentityTemplate.Servicios
{

    public interface IServicioCURP
    {
        Task<CURPDecodificado> ObtenerDatos(string curp);
    }


    public class ServicioCURP : IServicioCURP
    {
        private readonly IConfiguration _configuracion;

        public ServicioCURP(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<CURPDecodificado> ObtenerDatos(string curp)
        {
            var url = _configuracion.GetSection("TokenBearerCURP").GetSection("URL").Value;
            var token = _configuracion.GetSection("TokenBearerCURP").GetSection("Token").Value;

            try
            {
                var cliente = new HttpClient();

                CURP objetoJSON = new CURP()
                {
                    curp = curp
                };

                cliente.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var objetoSerializado = JsonSerializer.Serialize<CURP>(objetoJSON);

                HttpContent contenido = new StringContent(objetoSerializado, System.Text.Encoding.UTF8, "application/json");

                var respuesta = await cliente.PostAsync(url, contenido);


                if (respuesta.IsSuccessStatusCode)
                {
                    var resultado = await respuesta.Content.ReadAsStringAsync();

                    var resultadoFinal = JsonSerializer.Deserialize<CURPDecodificado>(resultado);

                    return resultadoFinal;
                }
            }
            catch (Exception ex)
            {
                //Manejar la exepcion
            }

            return null;
        }
    }
}
