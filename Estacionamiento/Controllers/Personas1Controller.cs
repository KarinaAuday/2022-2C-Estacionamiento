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
    //HECHO CON SCAFOLDING
    public class Personas1Controller : Controller
    {
        private readonly EstacionamientoContext _context;

        public Personas1Controller(EstacionamientoContext context)
        {
            _context = context;
            //#region primer persona prueba
            ////pregunto a ver si hay algo en el contexto. aca me crea una primera persona si no hay niguna
            //if (!_context.Personas.Any())
            //{

            //    //voy a crear una persona a
            //    Persona persona = new Persona()
            //    {
            //        Nombre = "Charly",
            //        Apellido = "Garcia",
            //        Dni = 55667788,
            //        Email = "charly@ort.edu.ar"

            //    };
            //    _context.Personas.Add(persona);
            //    _context.SaveChanges();
            //}
            //#endregion
        }

        // GET: Personas1
        public async Task<IActionResult> Index()
        {
            //Saco el Async y el Await
            return View(_context.Personas.ToList());
        }

        // GET: Personas1/Details/5
        //En este caso puedo pasar un id para que me muestre la persona con ese id. aca cheke que no sea nulo
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //aca busca a la persona por id
            var persona = _context.Personas
                .FirstOrDefault(m => m.Id == id);
            if (persona == null)
            {
                //lo pruebo pasando nada y la respuesta en not found
                //return NotFound();
                //agregomensaje
                return Content($"La persona con id {id} no fue encontrada");
            }

            return View(persona);
        }

        // GET: Personas1/Create
        //puedo agregar o no el GET, si no lo agrego toma que es el get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // el objeto persona en este caso lo crea el Model Binding
        //modifico el Async
        public IActionResult Create(String textoExtra ,[Bind("Id,Id2,Dni,Apellido,Nombre,Email")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas1/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = _context.Personas.Find(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Id2,Dni,Apellido,Nombre,Email")] Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //hace el Update si es valido el modelo. 
                    //nosotros vamos a hacerlo eligiendo que campos actualizar, como no queremos que nos falle haremos lo sieguiente
                    var personaEnDb = _context.Personas.Find(persona.Id);
                    if (personaEnDb!= null)
                    {
                        //Actualizamos EN la DB las PROPIEDADES que quiero cambiar
                        //Esto es importante para una actualizacion parcial
                        personaEnDb.Nombre = persona.Nombre;
                        personaEnDb.Apellido = persona.Apellido;
                        _context.Update(personaEnDb);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Id))
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
            return View(persona);
        }

        // GET: Personas1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
