using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JACR__20241103.Models;

namespace JACR__20241103.Controllers
{
    public class ReferenciasPersonalesController : Controller
    {
        private readonly JCT20241103Context _context;

        public ReferenciasPersonalesController(JCT20241103Context context)
        {
            _context = context;
        }

        // GET: ReferenciasPersonales
        public async Task<IActionResult> Index()
        {
            var jCT20241103Context = _context.ReferenciasPersonales.Include(r => r.Empleado);
            return View(await jCT20241103Context.ToListAsync());
        }

        // GET: ReferenciasPersonales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReferenciasPersonales == null)
            {
                return NotFound();
            }

            var referenciasPersonale = await _context.ReferenciasPersonales
                .Include(r => r.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referenciasPersonale == null)
            {
                return NotFound();
            }

            return View(referenciasPersonale);
        }

        // GET: ReferenciasPersonales/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id");
            return View();
        }

        // POST: ReferenciasPersonales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,Nombre,Apellido,Telefono")] ReferenciasPersonale referenciasPersonale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referenciasPersonale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", referenciasPersonale.EmpleadoId);
            return View(referenciasPersonale);
        }

        // GET: ReferenciasPersonales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReferenciasPersonales == null)
            {
                return NotFound();
            }

            var referenciasPersonale = await _context.ReferenciasPersonales.FindAsync(id);
            if (referenciasPersonale == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", referenciasPersonale.EmpleadoId);
            return View(referenciasPersonale);
        }

        // POST: ReferenciasPersonales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,Nombre,Apellido,Telefono")] ReferenciasPersonale referenciasPersonale)
        {
            if (id != referenciasPersonale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referenciasPersonale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenciasPersonaleExists(referenciasPersonale.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", referenciasPersonale.EmpleadoId);
            return View(referenciasPersonale);
        }

        // GET: ReferenciasPersonales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReferenciasPersonales == null)
            {
                return NotFound();
            }

            var referenciasPersonale = await _context.ReferenciasPersonales
                .Include(r => r.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referenciasPersonale == null)
            {
                return NotFound();
            }

            return View(referenciasPersonale);
        }

        // POST: ReferenciasPersonales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReferenciasPersonales == null)
            {
                return Problem("Entity set 'JCT20241103Context.ReferenciasPersonales'  is null.");
            }
            var referenciasPersonale = await _context.ReferenciasPersonales.FindAsync(id);
            if (referenciasPersonale != null)
            {
                _context.ReferenciasPersonales.Remove(referenciasPersonale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenciasPersonaleExists(int id)
        {
          return (_context.ReferenciasPersonales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
