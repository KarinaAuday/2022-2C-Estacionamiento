using Estacionamiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    public class HomeController : Controller
    {
       

        public HomeController ()
        {
        }

        public IActionResult Index()
        {
           // numero = 5555;
            return View(model: "pepe");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MostrarNumeros(List<int> numeritos)
        {
            numeritos = DameNumeros();
            return View(numeritos);
        }

        private List<int> DameNumeros()
        {
            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 20 };
            return DamePares(numeros);
        }

        private List<int> DamePares( List<int> ListNumeros)
        {
            var pares = ListNumeros.Where(num => num % 2 == 0);
            //oredeno de manera descendente y pongo una condicion
            var pares2 = ListNumeros.Where(num => num > 4 && num < 20).OrderByDescending(num => num);
            // lo llevo a ToList para que lo traiga en una coleccion. antes de esto esta en modelo de consulta.
            //se concreta la consulta al pasarla a la lsita
            
            

            return pares.ToList();
        }
       // public IActionResult Index2()
        //{
          //  return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
