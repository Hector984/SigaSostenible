using AutoMapper;
using IdentityTemplate.Data;
using IdentityTemplate.Helpers;
using IdentityTemplate.Models.VariablesDeSeguimiento;
using IdentityTemplate.ViewModels.VariablesSeguimiento;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Controllers.VariablesSeguimiento
{
    public class VariableSesguimientoController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly ICatalogosHelpers _catalogosHelpers;
        private readonly IMapper _mapper;

        public VariableSesguimientoController(ApplicationDBContext applicationDBContext, ICatalogosHelpers catalogosHelpers,
            IMapper mapper)
        {
            _applicationDBContext = applicationDBContext;
            _catalogosHelpers = catalogosHelpers;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {

            //Obtenemos las unidades meta
            var unidadesMeta = await _catalogosHelpers.ObtenerUnidadesMeta();

            var variableDeSeguimiento = new VariableSeguimientoViewModel()
            {
                UnidadesMeta = unidadesMeta,
            };

            return View(variableDeSeguimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(VariableSeguimientoViewModel variableSeguimientoViewModel)
        {

            if(!ModelState.IsValid)
            {
                return View(variableSeguimientoViewModel);
            }

            var modeloVariableSeguimiento = _mapper.Map<VariableSeguimiento>(variableSeguimientoViewModel);

            _applicationDBContext.Add(modeloVariableSeguimiento);

            await _applicationDBContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
