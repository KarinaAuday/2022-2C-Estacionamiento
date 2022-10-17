using Estacionamiento.Hepers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Models
{
    public class Rol :IdentityRole<int>
    {
        //Constructores
        public Rol() : base() 
        {

        }

        public Rol( string name) : base (name )
        {

        }
        //puedo sacar ahora el Id pues ya va a heredar de identityRol
       // public int Id { get; set; }

        [Display (Name = Alias.RolName)]  
        public  override string Name {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}
