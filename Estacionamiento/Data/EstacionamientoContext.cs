using Estacionamiento.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Estacionamiento.Data
{
    // me agregar el paquete entityframework
    public class EstacionamientoContext : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
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

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Telefonos> TelefonosP { get; set; }

        public DbSet<Cliente> Clientes { get; set; }


        public DbSet<ClienteVehiculo> ClientesVehiculos { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Rol> Roles{ get; set; }



        // En este metodo OnModelCreating hacemos todas definiciones que necesitamos
        // para representar nuestras entidades en la Base de datos. Es lo minimo para poder usar luego Identity


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pago>().Property(pa => pa.Monto).HasColumnType("decimal(38,10)");

            //relaciones muchos a muchos por medio de fluent API
            //Con el hasKey le indico cual es la clave primaria , o poniendo Key arriba del atributo (cuadno uso otro nombre que no sea por defecto classnameId)


            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId, cv.VehiculoId });

            //Ahota defino la relacion muchos a muchos
            //Tiene 1 cliente que tiene muchos vehiculos 
            modelBuilder.Entity<ClienteVehiculo>()
                .HasOne(cv => cv.Cliente)
                .WithMany(cli => cli.VehiculosAutorizados)
                .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                .HasOne(cv => cv.Vehiculo)
                .WithMany(vehiculo => vehiculo.PersonasAutorizadas)
                .HasForeignKey(cv => cv.VehiculoId);

            //Modifico la Entidad Identity User para que guarde en Las tablas que yo quiero
            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            //Relacion Muchos a Muchos
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

        }

        public DbSet<Estacionamiento.Models.Vehiculo> Vehiculo { get; set; }

        public DbSet<Estacionamiento.Models.Cliente> Cliente { get; set; }

        public DbSet<Estacionamiento.Models.Telefonos> Telefonos { get; set; }
    }

}
