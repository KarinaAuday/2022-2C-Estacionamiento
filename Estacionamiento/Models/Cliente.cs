using Estacionamiento.Hepers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Cliente : Persona
    {

        [Range(Restrictions.FloorCUIL, Restrictions.CeilCUIL, ErrorMessage = ErrMsgs.RangoMinMax)]
        public long CUIT { get; set; }

        

        public List<ClienteVehiculo> VehiculosAutorizados { get; set; }

    }
}
