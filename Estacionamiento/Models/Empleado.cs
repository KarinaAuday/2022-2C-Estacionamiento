﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Empleado : Persona
    {
        public int Id { get; set; }
        public String Legajo { get; set; }
    }
}
