using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Persona
    {
        public Persona()
        {

        }

        public Persona(string nombre, string apellido)
        {
            Apellido = apellido;
            Nombre = nombre;

        }


        public int Id { get; set; }

        public Guid Id2 { get; set; }


        [Range(1, 99999999, ErrorMessage = "Dni Invalido")]
        [Display (Name ="Docu")]
        public int Dni { get => dni; set => dni = value; }

        private int dni;

       [StringLength(50, MinimumLength = 2, ErrorMessage ="Cantidad invalida de caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Cantidad invalida de caracteres")]

        public string Nombre { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string NombreCompleto
        {
            get
            {
                return $"{Apellido}, {Nombre}";
            }
        }


       public Direccion Direccion { get; set; }

        public List<Telefonos> Telefonos { get; set; }



    }
}

