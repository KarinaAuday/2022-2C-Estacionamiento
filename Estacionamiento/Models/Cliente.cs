using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Cliente : Persona
    {
        public Cliente(string nombre, string apellido, long cuil) : base(nombre, apellido)
        {
            Cuil = cuil;
        }
        public long Cuil { get; set; }
    }
}
