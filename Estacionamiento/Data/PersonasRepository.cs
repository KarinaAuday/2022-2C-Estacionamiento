using Estacionamiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Data
{
    public class PersonasRepository
    {
        private List<Persona> _personas;

        public PersonasRepository()
        {
            _personas = new List<Persona>();
            Persona persona = new Persona() { Nombre = "Luis", Apellido = "Spinetta", Email = "LSpinetta@gmail.com" };
            Persona persona2 = new Persona() { Nombre = "Chaly", Apellido = "Garcia", Email = "Cgarcia@gmail.com" };
            _personas.Add(persona);
            _personas.Add(persona2);
        }

        public List<Persona> Personas
        {

            get { return _personas; }
            set { _personas = value; }

        }
    }
}
