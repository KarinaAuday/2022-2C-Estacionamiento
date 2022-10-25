using Estacionamiento.Data;
using Estacionamiento.Models;
using Estacionamiento.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamiento.Controllers
{
    //manejo de cuentas. 

    public class AccountController : Controller
    {
        //private readonly EstacionamientoContext _context;
        private readonly UserManager<Persona> _userManager;
        private readonly SignInManager<Persona> _signinManager;
        //private readonly RoleManager<Rol> _rolManager;
       //private const string passDefault = "Password1!";

        public AccountController(UserManager<Persona> userManager,SignInManager<Persona> signInManager) {
            this._userManager = userManager;
            this._signinManager = signInManager;
        
        }

        //[HttpGet]
       // public IActionResult EmailDisponible(string email)
        //{
         //   var emailUsado = _context.Personas.Any(p => p.Email == email);

        //    if (!emailUsado)
        //    {
        //        //Si no está el Email usado, entonces, el email está disponible.                
        //        return Json(true);
        //    }
        //    else
        //    {
        //        //El Email ya está en uso, entonces, no se cumple la validación, Se devuelve un mensaje de error.
        //        return Json($"El correo {email} ya está en uso.");
        //    }
        //}

        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]

        //Pued usar Bind o no, siempre tratara de machear los que llega con las propiedades del model
        public async Task <ActionResult> Registrar([Bind("Email,Password,ConfirmacionPassword")]RegistracionViewModel viewModel)
        {
            //Hago con model lo que necesito.

            if (ModelState.IsValid)
            {
                Cliente clienteACrear = new Cliente();
                {
                    clienteACrear.Email = viewModel.Email;
                    clienteACrear.UserName = viewModel.Email;
                }
                //En este caso si se usar el metodo create asyn 
                //Esto me devuelve un identity Result ,  un resultado booleano
                //Agrego la password , y el create se encarga de tomar este string y hacer el hashing
                var resultadoCreacion = await  _userManager.CreateAsync(clienteACrear, viewModel.Password);

                if (resultadoCreacion.Succeeded)
                {
                    //Agrego el rol, pero antes verifico solo en este caso si existen los roles 
                   // CrearRolesBase();


                    //le agrego el rol de cliente por ejemplo.
                    //var resultado =  _userManager.AddToRoleAsync(clienteACrear, "Cliente");

                    //if (resultado.Succeeded)
                    //{
                       
                    
                    //pudo crear - le hago sign-in directamente. que no sea persistente, o sea que no guarde en cookie
                    await _signinManager.SignInAsync(clienteACrear, isPersistent: false);

                    // redirecciona con el id del Cliente 
                    return RedirectToAction("Edit", "Personas1", new { id = clienteACrear.Id });
                    
                    //return RedirectToAction("Index", "Home");
                    //}

                    //Si no fué exitoso por ejemplo, podría volver atráz el cambio o no.
                }

                //no pudo
                //tratamiento de errores , con el forEach
                foreach (var error in resultadoCreacion.Errors)
                {
                    //Estos errores se mostraran en la vista
                    ModelState.AddModelError(string.Empty, error.Description);

                }
            }

            return View(viewModel);
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> IniciarSesion( Login loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //metodo asincronico para password adato asincronico todo
                //le paso directamente el email (username)
                //recordarme lo defino para ver si defini que sea persistente o no
               var resultado =  await _signinManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.Recordarme, false);
                //me devuelve un signinresult
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                //agrego un errror si no pudo procesar
                ModelState.AddModelError(String.Empty, "Inicio de Sesión inválida");
            }
            return View(loginViewModel);
        }

        
        public async Task<IActionResult> CerrarSesion()
        {
            //Aca cierro sesion, le dice al browser que elimine esa cookie
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //public ActionResult IniciarSesion(string returnurl)
        //{
        //    TempData["returnUrl"] = returnurl;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> IniciarSesion(Login viewModel)
        //{
        //    string returnUrl = TempData["returnUrl"] as string;

        //    if (ModelState.IsValid)
        //    {
        //        var resultadoSignIn = await _signinManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.Recordarme, false);

        //        if (resultadoSignIn.Succeeded)
        //        {
        //            if (!string.IsNullOrEmpty(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }

        //            return RedirectToAction("Index", "Home");
        //        }

        //        ModelState.AddModelError(string.Empty, "Inicio de sesión inválido");
        //    }

        //    return View(viewModel);
        //}

        //public async Task<ActionResult> CerrarSesion()
        //{
        //    await _signinManager.SignOutAsync();

        //    return RedirectToAction("Index", "home");
        //}

        //[HttpGet]
        //public IActionResult AccesoDenegado()
        //{
        //    return View();
        //}


        //private async Task CrearRolesBase()
        //{
        //    List<string> roles = new List<string>() { "Administrator", "Cliente", "Empleado", "UsuarioBase" };

        //    foreach (string rol in roles)
        //    {
        //        await CrearRole(rol);
        //    }
        //}

        //private async Task CrearRole(string rolName)
        //{
        //    if (!await _rolManager.RoleExistsAsync(rolName))
        //    {
        //        await _rolManager.CreateAsync(new Rol(rolName));
        //    }
        //}


        //public async Task<IActionResult> CrearAdmin()
        //{
        //    Persona account = new Persona()
        //    {
        //        Nombre = "Admin",
        //        Apellido = "Del Mañana",
        //        Email = "admin@admin.com",
        //        UserName = "admin@admin.com"
        //    };

        //    var resuAdm = await _userManager.CreateAsync(account, passDefault);
        //    if (resuAdm.Succeeded)
        //    {
        //        string rolAdm = "Administrador";
        //        await CrearRole(rolAdm);
        //        await _userManager.AddToRoleAsync(account, rolAdm);
        //        TempData["Mensaje"] = $"Empleado creado {account.Email} y {passDefault}";
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        //public async Task<IActionResult> CrearEmpleado()
        //{
        //    Empleado account = new Empleado()
        //    {
        //        Nombre = "Empleado",
        //        Apellido = "Del Año",
        //        Email = "empleado@empleado.com",
        //        UserName = "empleado@empleado.com"
        //    };

        //    var resuAdm = await _userManager.CreateAsync(account, passDefault);
        //    if (resuAdm.Succeeded)
        //    {
        //        string rolAdm = "Empleado";
        //        await CrearRole(rolAdm);
        //        await _userManager.AddToRoleAsync(account, rolAdm);
        //        TempData["Mensaje"] = $"Empleado creado {account.Email} y {passDefault}";
        //    }

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
