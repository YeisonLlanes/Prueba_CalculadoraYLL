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
    public class OperadorController : Controller
    {
        private readonly DbCalculadoraContext _context;

        public OperadorController(DbCalculadoraContext context)
        {
            _context = context;
        }

        // GET: Operador
        public async Task<IActionResult> Index()
        {
            var dbCalculadoraContext = _context.Operadores.Include(o => o.IdPrioridadNavigation).Include(o => o.IdUbicacionNavigation);
            return View(await dbCalculadoraContext.ToListAsync());
        }

        // GET: Operador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Operadores == null)
            {
                return NotFound();
            }

            var operadores = await _context.Operadores
                .Include(o => o.IdPrioridadNavigation)
                .Include(o => o.IdUbicacionNavigation)
                .FirstOrDefaultAsync(m => m.IdOperador == id);
            if (operadores == null)
            {
                return NotFound();
            }

            return View(operadores);
        }

        // GET: Operador/Create
        public IActionResult Create()
        {
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridades", "IdPrioridades");
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "IdUbicacion");
            return View();
        }

        // POST: Operador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperador,Operador,IdPrioridad,IdUbicacion")] Operadores operadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridades", "IdPrioridades", operadores.IdPrioridad);
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "IdUbicacion", operadores.IdUbicacion);
            return View(operadores);
        }

        // GET: Operador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Operadores == null)
            {
                return NotFound();
            }

            var operadores = await _context.Operadores.FindAsync(id);
            if (operadores == null)
            {
                return NotFound();
            }
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridades", "IdPrioridades", operadores.IdPrioridad);
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "IdUbicacion", operadores.IdUbicacion);
            return View(operadores);
        }

        // POST: Operador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperador,Operador,IdPrioridad,IdUbicacion")] Operadores operadores)
        {
            if (id != operadores.IdOperador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperadoresExists(operadores.IdOperador))
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
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridades", "IdPrioridades", operadores.IdPrioridad);
            ViewData["IdUbicacion"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "IdUbicacion", operadores.IdUbicacion);
            return View(operadores);
        }

        // GET: Operador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Operadores == null)
            {
                return NotFound();
            }

            var operadores = await _context.Operadores
                .Include(o => o.IdPrioridadNavigation)
                .Include(o => o.IdUbicacionNavigation)
                .FirstOrDefaultAsync(m => m.IdOperador == id);
            if (operadores == null)
            {
                return NotFound();
            }

            return View(operadores);
        }

        // POST: Operador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operadores == null)
            {
                return Problem("Entity set 'DbCalculadoraContext.Operadores'  is null.");
            }
            var operadores = await _context.Operadores.FindAsync(id);
            if (operadores != null)
            {
                _context.Operadores.Remove(operadores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperadoresExists(int id)
        {
          return (_context.Operadores?.Any(e => e.IdOperador == id)).GetValueOrDefault();
        }
    }
}
