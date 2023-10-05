using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaYeisonLlanes.Models;

namespace PruebaYeisonLlanes.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly DbCalculadoraContext _context;

        public HistoricoController(DbCalculadoraContext context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
  
            var dbCalculadoraContext = _context.Historicos.Include(h => h.IdUsuarioNavigation);
            return View(await dbCalculadoraContext.ToListAsync());
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Historicos == null)
            {
                return NotFound();
            }

            var historicos = await _context.Historicos
                .Include(h => h.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdHistorico == id);
            if (historicos == null)
            {
                return NotFound();
            }

            return View(historicos);
        }

        // GET: Historico/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistorico,Historico,Fecha,IdUsuario")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", historicos.IdUsuario);
            return View(historicos);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Historicos == null)
            {
                return NotFound();
            }

            var historicos = await _context.Historicos.FindAsync(id);
            if (historicos == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", historicos.IdUsuario);
            return View(historicos);
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHistorico,Historico,Fecha,IdUsuario")] Historicos historicos)
        {
            if (id != historicos.IdHistorico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricosExists(historicos.IdHistorico))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", historicos.IdUsuario);
            return View(historicos);
        }

        // GET: Historico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Historicos == null)
            {
                return NotFound();
            }

            var historicos = await _context.Historicos
                .Include(h => h.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdHistorico == id);
            if (historicos == null)
            {
                return NotFound();
            }

            return View(historicos);
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Historicos == null)
            {
                return Problem("Entity set 'DbCalculadoraContext.Historicos'  is null.");
            }
            var historicos = await _context.Historicos.FindAsync(id);
            if (historicos != null)
            {
                _context.Historicos.Remove(historicos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricosExists(int id)
        {
          return (_context.Historicos?.Any(e => e.IdHistorico == id)).GetValueOrDefault();
        }
    }
}
