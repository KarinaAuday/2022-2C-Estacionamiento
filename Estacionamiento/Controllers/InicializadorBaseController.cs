using Estacionamiento.Data;
using Estacionamiento.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    public class InicializadorBaseController : Controller
    {
        private readonly EstacionamientoContext _context;
        public InicializadorBaseController(EstacionamientoContext contexto)
        {
           this._context = contexto;
        }
        public IActionResult Incializar()
        {
            IncializarPersonas();

            return RedirectToAction("Index", "Personas1");
        }

        private void IncializarPersonas()
        {
            #region primer persona prueba
            //pregunto a ver si hay algo en el contexto. aca me crea una primera persona si no hay niguna
            if (!_context.Personas.Any())
            {

                //voy a crear una persona a
                Persona persona = new Persona()
                {
                    Nombre = "Charly",
                    Apellido = "Garcia",
                    Dni = 55667788,
                    Email = "charly@ort.edu.ar"

                };
                _context.Personas.Add(persona);
                _context.SaveChanges();

                Persona persona2 = new Persona()
                {
                     
                    Nombre = "Luis",
                    Apellido = "Alberto Spinetta",
                    Dni = 55228788,
                    Email = "LASy@ort.edu.ar"

                };
                _context.Personas.Add(persona2);
                _context.SaveChanges();
            }
            }
            #endregion
            
        }
    }
