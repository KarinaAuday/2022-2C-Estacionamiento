using Estacionamiento.Hepers;
using Estacionamiento.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.ViewModels
{
    public class RegistracionViewModel
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [EmailAddress(ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        //[Remote(action: "EmailDisponible", controller:"Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password, ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password, ErrorMessage = ErrMsgs.NoValido)]
        //Me permite comparar a password
        [Compare("Password", ErrorMessage = ErrMsgs.PassMissmatch)]
        [Display(Name = Alias.PassConfirm)]
        public string ConfirmacionPassword { get; set; }
    }
}
