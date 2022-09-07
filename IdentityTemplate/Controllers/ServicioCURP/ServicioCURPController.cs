using IdentityTemplate.Models.CURP;
using IdentityTemplate.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace IdentityTemplate.Controllers.ServicioCURP
{
    [System.Web.Http.Route("api/curp")]   
    [ApiController]
    public class ServicioCURPController : ControllerBase
    {
        private readonly IServicioCURP _servicioCURP;

        public ServicioCURPController(IServicioCURP servicioCURP)
        {
            _servicioCURP = servicioCURP;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{curp}")]
        public async Task<CURPDecodificado> ObtenerDatos(string curp)
        {
            return await _servicioCURP.ObtenerDatos(curp);
        }
    }
}
