using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class ClienteVehiculo
    {
        [Key]
        public int ClienteId { get; set; }
        [Key]
        public int VehiculoId { get; set; }
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public bool ResponsablePrincipal { get; set; }
    }
}

