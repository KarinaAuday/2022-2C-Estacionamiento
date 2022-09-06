using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class PersonasVehiculos
    {

        public int PersonaId { get; set; }
        public int VehiculosId { get; set; }

        public Persona Persona { get; set; }







        public Vehiculos Vehiculo { get; set; }
    }
}
