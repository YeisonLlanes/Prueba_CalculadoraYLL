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
    public class UbicacionController : Controller
    {
        private readonly DbCalculadoraContext _context;

        public UbicacionController(DbCalculadoraContext context)
        {
            _context = context;
        }

        // GET: Ubicacion
        public async Task<IActionResult> Index()
        {
              return _context.Ubicaciones != null ? 
                          View(await _context.Ubicaciones.ToListAsync()) :
                          Problem("Entity set 'DbCalculadoraContext.Ubicaciones'  is null.");
        }

        // GET: Ubicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicaciones = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.IdUbicacion == id);
            if (ubicaciones == null)
            {
                return NotFound();
            }

            return View(ubicaciones);
        }

        // GET: Ubicacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ubicacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUbicacion,Ubicacion")] Ubicaciones ubicaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ubicaciones);
        }

        // GET: Ubicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicaciones = await _context.Ubicaciones.FindAsync(id);
            if (ubicaciones == null)
            {
                return NotFound();
            }
            return View(ubicaciones);
        }

        // POST: Ubicacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUbicacion,Ubicacion")] Ubicaciones ubicaciones)
        {
            if (id != ubicaciones.IdUbicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionesExists(ubicaciones.IdUbicacion))
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
            return View(ubicaciones);
        }

        // GET: Ubicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicaciones = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.IdUbicacion == id);
            if (ubicaciones == null)
            {
                return NotFound();
            }

            return View(ubicaciones);
        }

        // POST: Ubicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ubicaciones == null)
            {
                return Problem("Entity set 'DbCalculadoraContext.Ubicaciones'  is null.");
            }
            var ubicaciones = await _context.Ubicaciones.FindAsync(id);
            if (ubicaciones != null)
            {
                _context.Ubicaciones.Remove(ubicaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionesExists(int id)
        {
          return (_context.Ubicaciones?.Any(e => e.IdUbicacion == id)).GetValueOrDefault();
        }
    }
}
