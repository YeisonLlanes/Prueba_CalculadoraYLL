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
    public class LogController : Controller
    {
        private readonly DbCalculadoraContext _context;

        public LogController(DbCalculadoraContext context)
        {
            _context = context;
        }

        // GET: Log
        public async Task<IActionResult> Index()
        {
              return _context.Logs != null ? 
                          View(await _context.Logs.ToListAsync()) :
                          Problem("Entity set 'DbCalculadoraContext.Logs'  is null.");
        }

        // GET: Log/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var logs = await _context.Logs
                .FirstOrDefaultAsync(m => m.IdLog == id);
            if (logs == null)
            {
                return NotFound();
            }

            return View(logs);
        }

        // GET: Log/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Log/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLog,Detalle,Fecha")] Logs logs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logs);
        }

        // GET: Log/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var logs = await _context.Logs.FindAsync(id);
            if (logs == null)
            {
                return NotFound();
            }
            return View(logs);
        }

        // POST: Log/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLog,Detalle,Fecha")] Logs logs)
        {
            if (id != logs.IdLog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogsExists(logs.IdLog))
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
            return View(logs);
        }

        // GET: Log/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var logs = await _context.Logs
                .FirstOrDefaultAsync(m => m.IdLog == id);
            if (logs == null)
            {
                return NotFound();
            }

            return View(logs);
        }

        // POST: Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logs == null)
            {
                return Problem("Entity set 'DbCalculadoraContext.Logs'  is null.");
            }
            var logs = await _context.Logs.FindAsync(id);
            if (logs != null)
            {
                _context.Logs.Remove(logs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogsExists(int id)
        {
          return (_context.Logs?.Any(e => e.IdLog == id)).GetValueOrDefault();
        }
    }
}
