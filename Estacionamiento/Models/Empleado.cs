using Estacionamiento.Hepers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Empleado : Persona
    {
        //[Required(ErrorMessage = ErrMsgs.Requerido)]
        //[StringLength(Restrictions.FloorL4, MinimumLength = Restrictions.CeilL1, ErrorMessage = ErrMsgs.FixedSize)]
        public string CodigoEmpleado { get; set; }
        public String Area { get; set; }

        
    }
}
