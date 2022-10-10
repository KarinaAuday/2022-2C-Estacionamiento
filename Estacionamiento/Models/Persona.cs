using Estacionamiento.Hepers;
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

        public  int Id2 { get; set; }

        [Required (ErrorMessage = ErrMsgs.Requerido)]
        [Range(1, 99999999, ErrorMessage = "Dni Invalido")]
        [Display (Name ="Docu")]
        public int Dni { get => dni; set => dni = value; }

        private int dni;

       
       [StringLength(50, MinimumLength = 2, ErrorMessage ="Cantidad invalida de caracteres")]
        public string Apellido { get; set; }

       
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Cantidad invalida de caracteres")]
        [Display (Name ="Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [EmailAddress(ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        public string Email { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

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

