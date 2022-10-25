using Estacionamiento.Hepers;
using Estacionamiento.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = ErrMsgs.NoValido)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password)]
        [Display(Name = Alias.Password)]
        public string Password { get; set; }


        public bool Recordarme { get; set; } = false;
    }
}
