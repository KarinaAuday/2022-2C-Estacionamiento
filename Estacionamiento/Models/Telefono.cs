using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public int CodArea { get; set; }

        public int Numero { get; set; }

        public int PersonaId { get; set; }
    }
}
