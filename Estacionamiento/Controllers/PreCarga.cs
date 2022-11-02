using Estacionamiento.Data;
using Estacionamiento.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
 

    public class PreCarga : Controller
    {
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly EstacionamientoContext _context;
        private List<string> roles = new List<string>() { "Admin", "Cliente", "Empleado", "Usuario" };
        public PreCarga(UserManager<Persona> userManager,RoleManager<Rol> roleManager,EstacionamientoContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
          
        }
        public IActionResult Seed()
        {
            CrearRoles().Wait();
            CrearAdmin().Wait();
            CrearCliente().Wait();
            CrearEmpleado().Wait();
            CrearVehiculos().Wait();
            return RedirectToAction("Index", "Home",(new { mensaje = "Precarga Seed Finalizada" }));
        }

        private async Task CrearVehiculos()
        {

        }

        private async Task CrearEmpleado()
        {
            
        }

        private async Task CrearCliente()
        {
           
        }

        private async Task CrearAdmin()
        {
        
        }

        private async Task CrearRoles()
        {
           foreach(var rolName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(rolName))
                {
                    await _roleManager.CreateAsync(new Rol(rolName) );
                }
            }
        }
    }
}
