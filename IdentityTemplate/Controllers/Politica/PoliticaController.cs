using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityTemplate.Data;
using IdentityTemplate.Models.Catalogs;
using Microsoft.AspNetCore.Authorization;

namespace IdentityTemplate.Controllers
{
    [Authorize(Roles = "AdministradorNacional")]
    public class PoliticaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PoliticaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PoliticaAccion
        public async Task<IActionResult> Index()
        {
              return View(await _context.PoliticaAcciones.ToListAsync());
        }

        // GET: PoliticaAccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PoliticaAcciones == null)
            {
                return NotFound();
            }

            var politicaAccion = await _context.PoliticaAcciones
                .FirstOrDefaultAsync(m => m.PoliticaId == id);

            if (politicaAccion == null)
            {
                return NotFound();
            }

            return View(politicaAccion);
        }

        // GET: PoliticaAccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoliticaAccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoliticaAccionId,NombrePoliticaAccion")] Politica politicaAccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(politicaAccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(politicaAccion);
        }

        // GET: PoliticaAccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PoliticaAcciones == null)
            {
                return NotFound();
            }

            var politicaAccion = await _context.PoliticaAcciones.FindAsync(id);
            if (politicaAccion == null)
            {
                return NotFound();
            }
            return View(politicaAccion);
        }

        // POST: PoliticaAccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoliticaAccionId,NombrePoliticaAccion")] Politica politicaAccion)
        {
            if (id != politicaAccion.PoliticaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(politicaAccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliticaAccionExists(politicaAccion.PoliticaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(politicaAccion);
        }

        // GET: PoliticaAccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PoliticaAcciones == null)
            {
                return NotFound();
            }

            var politicaAccion = await _context.PoliticaAcciones
                .FirstOrDefaultAsync(m => m.PoliticaId == id);
            if (politicaAccion == null)
            {
                return NotFound();
            }

            return View(politicaAccion);
        }

        // POST: PoliticaAccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PoliticaAcciones == null)
            {
                return Problem("Entity set 'ApplicationDBContext.PoliticaAcciones'  is null.");
            }
            var politicaAccion = await _context.PoliticaAcciones.FindAsync(id);
            if (politicaAccion != null)
            {
                _context.PoliticaAcciones.Remove(politicaAccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliticaAccionExists(int id)
        {
          return _context.PoliticaAcciones.Any(e => e.PoliticaId == id);
        }
    }
}
