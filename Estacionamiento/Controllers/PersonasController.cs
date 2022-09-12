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
        // viebag es un metodo de transporte entre el controlador y la vista
        //Con el id puede pasar un dato y dinamicamente me muestra e resultado. pongo un string en la url y lo toma
        public IActionResult MostrarPersonas (int id )
        {
            ViewBag.Persona = DamePersona("Juan", "Perez" , id);
            return View();
        }
        //Mando parametro por queryString mostrarPersonas2?nombre=karina&apellido=perez&dni=222
        public IActionResult MostrarPersonas2(string nombre , string apellido, int dni)
        {
            ViewBag.Persona = DamePersona(nombre , apellido , dni);
            return View();
        }

        //creo un metodo para que me devuelva una persona mandando paramtro sin formulario
        private Persona DamePersona(string nombre, string apellido , int dni)
        {
            Persona persona = new Persona();
            {
                persona.Apellido = apellido;
                persona.Nombre = nombre;
                persona.Dni = dni;

            };
            return persona;
        }

    }
}
