using Estacionamiento.Data;
using Estacionamiento.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    public class VehiculosController1 : Controller
    {
        private readonly EstacionamientoContext _contexto;
        //Declaro constructor
        public VehiculosController1( EstacionamientoContext contexto)
        {
            this._contexto = contexto;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string patente,string marca, string color )
        {
            //Aca recibo la data y la guardo en el contexto
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Patente = patente;
            vehiculo.Marca = marca;
            vehiculo.Color = color;
            //aca esta el Db set que cree en el contexto estacionamientoContext2
            _contexto.Vehiculos.Add(vehiculo);
            _contexto.SaveChanges();
            return RedirectToAction("list");
        }

        public IActionResult List()
        {
            return View(_contexto.Vehiculos);
        }
    }
}
