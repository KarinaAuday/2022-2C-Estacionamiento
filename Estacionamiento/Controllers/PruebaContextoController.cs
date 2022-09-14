using Estacionamiento.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    public class PruebaContextoController : Controller
    {
        private EstacionamientoContext _baseDeDatos;
        public PruebaContextoController(EstacionamientoContext context)
        {
            this._baseDeDatos = context;
        }
    
        public IActionResult Index()
        {
           // develve una DbSet en lista
            var personasEnBd = _baseDeDatos.Personas.ToList();
          //Si  hay personas
            if (!personasEnBd.Any())
            {
               var personasAAgregar= PruebaPersona.GetPersonas();
                //todas las personas en un rango
                _baseDeDatos.Personas.AddRange(personasAAgregar);
                //gurda los cambios
                _baseDeDatos.SaveChanges();

            }

            personasEnBd = _baseDeDatos.Personas.ToList();
            return View();
        }
    }
}
