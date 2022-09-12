using Estacionamiento.Data;
using Estacionamiento.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    public class PersonasController : Controller
    {
        //Creo un DB context. Fuerzo a recibir un contexto de base de datos
      //  private readonly EstacionamientoContext _estacionamientoDB;
        
        //Mostrarme Personas
        public IActionResult Index()
        {
            //creo las Personas que traigo de la DB y la hago tolist
           // List<Persona> Personas = _estacionamientoDB.Personas.ToList();
            return View();
        }
        // Escuchar la solicitud de pedido de  Formulario  y darlo
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        // Recibe form y creo la persona
        [HttpPost]
        public IActionResult Create(string nombre, string apellido, int dni)
        {
            Persona persona1 = new Persona();
            persona1.Nombre = nombre;
            persona1.Apellido = apellido;
            persona1.Dni = dni;
            return RedirectToAction("Index");

        }

    }
}
