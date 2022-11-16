using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Direccion
    {
        [Key, ForeignKey("Cliente")]
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }

        public int numero { get; set; }

        public Cliente Cliente { get; set; }

    }
}
