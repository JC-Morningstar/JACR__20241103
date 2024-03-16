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
        // GET: ReferenciasPersonales/Create
        public IActionResult Create(int empleadoId)
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", empleadoId);
            return View();
        }



        // POST: ReferenciasPersonales/Create
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,EmpleadoId,Nombre,Apellido,Telefono")] ReferenciasPersonale referenciaPersonal)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(referenciaPersonal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Empleadoes", new { id = referenciaPersonal.EmpleadoId });
                }
                return View(referenciaPersonal);
            }

            // GET: ReferenciasPersonales/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var referenciaPersonal = await _context.ReferenciasPersonales.FindAsync(id);
                if (referenciaPersonal == null)
                {
                    return NotFound();
                }
                return View(referenciaPersonal);
            }

            // POST: ReferenciasPersonales/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,Nombre,Apellido,Telefono")] ReferenciasPersonale referenciaPersonal)
            {
                if (id != referenciaPersonal.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(referenciaPersonal);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ReferenciaPersonalExists(referenciaPersonal.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Details", "Empleados", new { id = referenciaPersonal.EmpleadoId });
                }
                return View(referenciaPersonal);
            }

            // GET: ReferenciasPersonales/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var referenciaPersonal = await _context.ReferenciasPersonales
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (referenciaPersonal == null)
                {
                    return NotFound();
                }

                return View(referenciaPersonal);
            }

            // POST: ReferenciasPersonales/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var referenciaPersonal = await _context.ReferenciasPersonales.FindAsync(id);
                _context.ReferenciasPersonales.Remove(referenciaPersonal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ReferenciaPersonalExists(int id)
            {
                return _context.ReferenciasPersonales.Any(e => e.Id == id);
            }
        }
    }
