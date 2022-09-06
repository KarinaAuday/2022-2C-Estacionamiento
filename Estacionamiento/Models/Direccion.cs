using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }

        public int Numero { get; set; }

        public int CodPostal { get; set; }

        [Required]
        public int PersonaId { get; set; }
    }
}
