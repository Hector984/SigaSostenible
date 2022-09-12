using IdentityTemplate.Data;
using IdentityTemplate.Models.Catalogos;
using IdentityTemplate.ViewModels.Catalogos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityTemplate.Controllers
{
    public class PoliticaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PoliticaController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var politicas = await _context.PoliticaAcciones.ToListAsync();

            politicas.OrderBy(p => p.PoliticaId);

            return View(politicas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Politica politica)
        {

            if(!ModelState.IsValid)
            {
                return View(politica);
            }

            _context.PoliticaAcciones.Add(politica);

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
