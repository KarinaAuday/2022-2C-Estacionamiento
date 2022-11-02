using Estacionamiento.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamiento.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Estacionamiento
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection builder)
        {


            //IServiceCollection serviceCollection = services.AddDbContext<EstacionamientoContext>(option => option.UseInMemoryDatabase(EstacionamientoDB);
            //Configurando con base de datos en memoria
            // builder.AddDbContext<EstacionamientoContext>(options => options.UseInMemoryDatabase("EstacionamientoDb"));
            //configurando SQL server uso de Local DB
            //configuro el conection String poner nombre curso

            // services.AddDbContext<EstacionamientoContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=EstacionamientoDB;Trusted_Connection=true"));
           
            //Aca puse el string de configuracion en el appsetting.json
            builder.AddDbContext<EstacionamientoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EstacionamientoDBCS")));

            #region Identity
            //donde almacena las entidades identity , pongo nuestro contexto
            builder.AddIdentity<Persona, Rol>().AddEntityFrameworkStores<EstacionamientoContext>();
            builder.Configure<IdentityOptions>(opciones =>
           {
               opciones.Password.RequireNonAlphanumeric = false;
               opciones.Password.RequireUppercase = false;
               opciones.Password.RequireLowercase = false;
               opciones.Password.RequireDigit = false;
               opciones.Password.RequiredLength = 5;
           }
            );
            //Password por defecto en la precarca Password1!
            #endregion
           // Para definir, donde lograr hacer un login de la cuenta ante un requerimiento de authenticación.
             builder.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                 opciones =>
                 {
                     opciones.LoginPath = "/Account/IniciarSesion";
                     opciones.AccessDeniedPath = "/Account/AccesoDenegado";
                 });

            builder.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Agrego la Auutenticacion antes de Autorizar

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
