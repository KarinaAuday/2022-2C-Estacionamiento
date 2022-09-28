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

        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //relaciones muchos a muchos por medio de fluent API
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId, cv.VehiculoId });

            modelBuilder.Entity<ClienteVehiculo>()
                .HasOne(cv => cv.Cliente)
                .WithMany(c => c.VehiculosAutorizados)
                .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                .HasOne(cv => cv.Vehiculo)
                .WithMany(v => v.PersonasAutorizadas)
                .HasForeignKey(cv => cv.VehiculoId);
        }

        public DbSet<Estacionamiento.Models.Vehiculo> Vehiculo { get; set; }
    }

}
