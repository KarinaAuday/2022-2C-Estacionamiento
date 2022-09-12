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
        //declaro el constructor. Esto sera como un repositorio de mi objeto Persona
        public EstacionamientoContext (DbContextOptions opcionesConfiguracion) : base (opcionesConfiguracion)
        {

        }
        // como lo haria
        public List<Persona> Personas { get; set; }
        // lo que nos ofrece ET que es mejor pero mismo concepto. DBSet tambien es una coleccion
        public DbSet<Direccion> Direcciones { get; set; }
    }
}
