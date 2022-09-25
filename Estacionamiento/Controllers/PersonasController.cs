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
        private readonly EstacionamientoContext _contexto;

        public PersonasController(EstacionamientoContext contexto)
        {
            this._contexto = contexto;
        }
        //Mostrarme Personas
        public IActionResult Index()
        {
            //creo las Personas que traigo de la DB y la hago tolist
            // List<Persona> Personas = _estacionamientoDB.Personas.ToList();

            // var personas = new PersonasRepository();
            //lista de personas
            // return View(personas.Personas);
            //  var personas2 = _contexto.Personas;
            //var personas3 = _contexto.Personas.ToList();

            return View(_contexto.Personas);
        }

        public IActionResult Index1()
        {
            //creo las Personas que traigo de la DB y la hago tolist
            // List<Persona> Personas = _estacionamientoDB.Personas.ToList();

            // var personas = new PersonasRepository();
            //lista de personas
            // return View(personas.Personas);
            //  var personas2 = _contexto.Personas;
            //var personas3 = _contexto.Personas.ToList();

            return View(_contexto.Personas);
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
            //aca me muestra la persona1 que le mando , puse ejemplo en create
           //aca agrega
            _contexto.Personas.Add(persona1);
            //aca guarda cambios
            _contexto.SaveChanges();
            //ahora muestro lo creado
            return RedirectToAction("index");


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

        public IActionResult MostrarListaPersonas()
        {
            List<Persona> personas = new List<Persona>();
            Persona persona1 = new Persona();
            Persona persona2 = new Persona();
            Persona persona3 = new Persona();

            persona1.Apellido = "Perez";
            persona1.Nombre = " Jose";

            persona2.Apellido = "Gonzalez";
            persona2.Nombre = "Mirtha";

            persona3.Apellido = "Rodriguez";
            persona3.Nombre = " Jorge";

            personas.Add(persona1);
            personas.Add(persona2);
            personas.Add(persona3);


            return View(personas);
        }
    }
}
