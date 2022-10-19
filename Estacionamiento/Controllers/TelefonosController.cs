using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estacionamiento.Data;
using Estacionamiento.Models;

namespace Estacionamiento.Controllers
{
    public class TelefonosController : Controller
    {
        private readonly EstacionamientoContext _context;

        public TelefonosController(EstacionamientoContext context)
        {
            _context = context;
        }

        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            var estacionamientoContext = _context.Telefonos.Include(t => t.Persona);
            return View(await estacionamientoContext.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonos = await _context.Telefonos
                .Include(t => t.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefonos == null)
            {
                return NotFound();
            }

            return View(telefonos);
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "NombreCompleto");
            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodArea,Numero,Principal,Tipo,PersonaId")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "NombreCompleto", telefonos.PersonaId);
            return View(telefonos);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonos = await _context.Telefonos.FindAsync(id);
            if (telefonos == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "NombreCompleto", telefonos.PersonaId);
            return View(telefonos);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodArea,Numero,Principal,Tipo,PersonaId")] Telefonos telefonos)
        {
            if (id != telefonos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonosExists(telefonos.Id))
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
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "NombreCompleto", telefonos.PersonaId);
            return View(telefonos);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonos = await _context.Telefonos
                .Include(t => t.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefonos == null)
            {
                return NotFound();
            }

            return View(telefonos);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonos = await _context.Telefonos.FindAsync(id);
            _context.Telefonos.Remove(telefonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonosExists(int id)
        {
            return _context.Telefonos.Any(e => e.Id == id);
        }
    }
}
