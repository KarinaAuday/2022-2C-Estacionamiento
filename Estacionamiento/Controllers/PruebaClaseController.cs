using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    public class PruebaClaseController : Controller
    {
          //ver ACA https://localhost:44381/pruebaclase/prueba 
        public ActionResult Prueba()
        {
            return View();
            //content devuelve el texto plano sin layout
            //return Content("HOLA");
        }
    }
}
