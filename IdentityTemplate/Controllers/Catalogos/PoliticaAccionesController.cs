﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityTemplate.Data;
using IdentityTemplate.Models.Catalogs;

namespace IdentityTemplate.Controllers.Catalogos
{
    public class PoliticaAccionesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PoliticaAccionesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PoliticaAcciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.PoliticaAccion.ToListAsync());
        }

        // GET: PoliticaAcciones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PoliticaAccion == null)
            {
                return NotFound();
            }

            var politicaAccion = await _context.PoliticaAccion
                .FirstOrDefaultAsync(m => m.PoliticaAccionId == id);
            if (politicaAccion == null)
            {
                return NotFound();
            }

            return View(politicaAccion);
        }

        // GET: PoliticaAcciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoliticaAcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoliticaAccionId,NombrePoliticaAccion")] PoliticaAccion politicaAccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(politicaAccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(politicaAccion);
        }

        // GET: PoliticaAcciones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PoliticaAccion == null)
            {
                return NotFound();
            }

            var politicaAccion = await _context.PoliticaAccion.FindAsync(id);
            if (politicaAccion == null)
            {
                return NotFound();
            }
            return View(politicaAccion);
        }

        // POST: PoliticaAcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PoliticaAccionId,NombrePoliticaAccion")] PoliticaAccion politicaAccion)
        {
            if (id != politicaAccion.PoliticaAccionId)
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
                    if (!PoliticaAccionExists(politicaAccion.PoliticaAccionId))
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

        // GET: PoliticaAcciones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PoliticaAccion == null)
            {
                return NotFound();
            }

            var politicaAccion = await _context.PoliticaAccion
                .FirstOrDefaultAsync(m => m.PoliticaAccionId == id);
            if (politicaAccion == null)
            {
                return NotFound();
            }

            return View(politicaAccion);
        }

        // POST: PoliticaAcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PoliticaAccion == null)
            {
                return Problem("Entity set 'ApplicationDBContext.PoliticaAccion'  is null.");
            }
            var politicaAccion = await _context.PoliticaAccion.FindAsync(id);
            if (politicaAccion != null)
            {
                _context.PoliticaAccion.Remove(politicaAccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliticaAccionExists(string id)
        {
          return _context.PoliticaAccion.Any(e => e.PoliticaAccionId == id);
        }
    }
}
