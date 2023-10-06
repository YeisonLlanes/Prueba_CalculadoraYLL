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
    public class NumeroController : Controller
    {
        private readonly DbCalculadoraContext _context;

        public NumeroController(DbCalculadoraContext context)
        {
            _context = context;
        }

        // GET: Numero
        public async Task<IActionResult> Index()
        {
              return _context.Numeros != null ? 
                          View(await _context.Numeros.ToListAsync()) :
                          Problem("Entity set 'DbCalculadoraContext.Numeros'  is null.");
        }

        // GET: Numero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Numeros == null)
            {
                return NotFound();
            }

            var numeros = await _context.Numeros
                .FirstOrDefaultAsync(m => m.IdNumero == id);
            if (numeros == null)
            {
                return NotFound();
            }

            return View(numeros);
        }

        // GET: Numero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNumero,Numero")] Numeros numeros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numeros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numeros);
        }

        // GET: Numero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Numeros == null)
            {
                return NotFound();
            }

            var numeros = await _context.Numeros.FindAsync(id);
            if (numeros == null)
            {
                return NotFound();
            }
            return View(numeros);
        }

        // POST: Numero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNumero,Numero")] Numeros numeros)
        {
            if (id != numeros.IdNumero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numeros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumerosExists(numeros.IdNumero))
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
            return View(numeros);
        }

        // GET: Numero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Numeros == null)
            {
                return NotFound();
            }

            var numeros = await _context.Numeros
                .FirstOrDefaultAsync(m => m.IdNumero == id);
            if (numeros == null)
            {
                return NotFound();
            }

            return View(numeros);
        }

        // POST: Numero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Numeros == null)
            {
                return Problem("Entity set 'DbCalculadoraContext.Numeros'  is null.");
            }
            var numeros = await _context.Numeros.FindAsync(id);
            if (numeros != null)
            {
                _context.Numeros.Remove(numeros);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumerosExists(int id)
        {
          return (_context.Numeros?.Any(e => e.IdNumero == id)).GetValueOrDefault();
        }
    }
}
