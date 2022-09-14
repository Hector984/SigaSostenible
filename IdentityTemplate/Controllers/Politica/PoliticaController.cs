using AutoMapper;
using IdentityTemplate.Data;
using IdentityTemplate.Helpers;
using IdentityTemplate.Models.Catalogos;
using IdentityTemplate.Models.VariableSesguimiento;
using IdentityTemplate.ViewModels.VariablesSeguimiento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityTemplate.Controllers
{
    public class PoliticaController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ICatalogosHelpers _catalogosHelpers;
        private readonly IMapper _mapper;

        public PoliticaController(ApplicationDBContext context, ICatalogosHelpers catalogosHelpers, IMapper mapper)
        {
            _context = context;
            _catalogosHelpers = catalogosHelpers;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var politicas = await _context.PoliticaAcciones.ToListAsync();

            politicas.OrderBy(p => p.PoliticaId);

            return View(politicas);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var politicas = await _catalogosHelpers.ObtenerPoliticas();

            var modeloBasePolitica = new PoliticaBaseViewModel()
            {
                Politicas = politicas
            };

            return View(modeloBasePolitica);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PoliticaViewModel politica)
        {

            if(!ModelState.IsValid)
            {
                return View(politica);
            }

            var modeloPolitica = _mapper.Map<Politica>(politica);

            _context.PoliticaAcciones.Add(modeloPolitica);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CrearEjeTematico(EjeTematicoViewModel politicaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", politicaViewModel);
            }

            var modeloEjeTematico = _mapper.Map<EjeTematico>(politicaViewModel);

            _context.EjesTematicos.Add(modeloEjeTematico);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var politica = await _context.PoliticaAcciones.FindAsync(id);

            if(politica is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(politica);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Politica politica)
        {

            if(id != politica.PoliticaId)
            {
                return RedirectToAction("Error", "Home");
            }

            if(!ModelState.IsValid)
            {
                return View(politica);
            }

            _context.Update(politica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            var politica = await _context.PoliticaAcciones.FindAsync(id);

            if (politica is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(politica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarPolitica(int politicaId)
        {

            var politicaAccion = await _context.PoliticaAcciones.FindAsync(politicaId);

            if(politicaAccion is null)
            {
                return RedirectToAction("Error", "Home");
            }

            _context.Remove(politicaAccion);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
