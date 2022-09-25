using Estacionamiento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Estacionamiento.Data
{
    // me agregar el paquete entityframework
    public class EstacionamientoContext : DbContext
    {
        //declaro el constructor. 
        public EstacionamientoContext (DbContextOptions <EstacionamientoContext> opcionesConfiguracion) : base (opcionesConfiguracion)
        {
            //Conecto a la Base de Datos

        }
        //DBSet es la coleccion que me permite hablar con la base de datos
        public DbSet<Persona> Personas { get; set; }
        // DBSet es lo que nos ofrece EF que es mejor que LIST pero mismo concepto. DBSet tambien es una coleccion
        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
