using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaYeisonLlanes.Models;

namespace PruebaYeisonLlanes.Controllers
{
    public class PrioridadController : Controller
    {
        private readonly DbCalculadoraContext _context;

        public PrioridadController(DbCalculadoraContext context)
        {
            _context = context;
        }

        // GET: Prioridad
        public async Task<IActionResult> Index()
        {
              return _context.Prioridades != null ? 
                          View(await _context.Prioridades.ToListAsync()) :
                          Problem("Entity set 'DbCalculadoraContext.Prioridades'  is null.");
        }

        // GET: Prioridad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prioridades == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades
                .FirstOrDefaultAsync(m => m.IdPrioridades == id);
            if (prioridades == null)
            {
                return NotFound();
            }

            return View(prioridades);
        }

        // GET: Prioridad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prioridad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrioridades,Prioridad")] Prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prioridades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prioridades);
        }

        // GET: Prioridad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prioridades == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }
            return View(prioridades);
        }

        // POST: Prioridad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrioridades,Prioridad")] Prioridades prioridades)
        {
            if (id != prioridades.IdPrioridades)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prioridades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioridadesExists(prioridades.IdPrioridades))
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
            return View(prioridades);
        }

        // GET: Prioridad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prioridades == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades
                .FirstOrDefaultAsync(m => m.IdPrioridades == id);
            if (prioridades == null)
            {
                return NotFound();
            }

            return View(prioridades);
        }

        // POST: Prioridad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prioridades == null)
            {
                return Problem("Entity set 'DbCalculadoraContext.Prioridades'  is null.");
            }
            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades != null)
            {
                _context.Prioridades.Remove(prioridades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioridadesExists(int id)
        {
          return (_context.Prioridades?.Any(e => e.IdPrioridades == id)).GetValueOrDefault();
        }
    }
}
