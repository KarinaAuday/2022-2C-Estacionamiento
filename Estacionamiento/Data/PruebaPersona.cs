using Estacionamiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Data
{
    public class PruebaPersona
    {
        public static List<Persona> GetPersonas()
        {
            Persona p1 = new Persona() { Nombre = "John", Apellido = "Lennon", Dni = 11111111 };
            Persona p2 = new Persona() { Nombre = "Pat", Apellido = "Metheny", Dni = 22222222 };
            Persona p3= new Persona() { Nombre = "Aretha", Apellido = "Franklin", Dni = 33333333 };
            Persona p4= new Persona() { Nombre = "Luisalberto", Apellido = "Spinetta", Dni = 44444444 };
            List<Persona> personas = new List<Persona>();
            personas.Add(p1);
            personas.Add(p2);
            personas.Add(p3);
            personas.Add(p4);
            return personas;
        }
    }
}
