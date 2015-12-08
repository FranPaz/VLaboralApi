namespace VLaboralApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using VlaboralApi.Infrastructure;
    using VLaboralApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VLaboralApi.Models.VLaboral_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VLaboralApi.Models.VLaboral_Context context)
        {
            //fpaz:Semillas para el llenado inicial de la bd
            
            #region Carga de ApplicationUser
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new VLaboral_Context()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new VLaboral_Context()));

            var user = new ApplicationUser()
            {
                UserName = "Administrador",
                Email = "overcode_dev@outlook.com",
                EmailConfirmed = true,
                FirstName = "Administrador",
                LastName = "Administrador",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3),
                Empleador = new Empleador { Cuit = "123", Rsocial = "Empleador 1", Descripcion = "Empleador de prueba 1" },
            };

            manager.Create(user, "qwerty123");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("Administrador");

            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
            #endregion

            var empleado = new Empleado
            {
                NombreApellido = "Emp1",
                Direccion = "Calle Falsa 123",
                FecNacimiento = DateTime.Now
            };
            context.Empleados.Add(empleado);

            #region carga rubros y subrubros

            var listaRubros = new List<Rubro>{
                new Rubro {Nombre = "Informatica", Descripcion="Rubro Informatica",
                    SubRubros = new List<SubRubro>{
                        new SubRubro { Nombre = "Administracion de Sistemas", Descripcion ="Subrubro Admin de sistemas"},
                        new SubRubro { Nombre = "Desarrollo de Software", Descripcion ="Subrubro Desarrollo de Software"},
                        new SubRubro { Nombre = "Soporte Tecnico", Descripcion ="Subrubro Soporte Tecnico"}
                    }
                },
                new Rubro {Nombre = "Diseño y Multimedia", Descripcion="Rubro Diseño y Multimedia",
                    SubRubros = new List<SubRubro>{
                        new SubRubro { Nombre = "Animaciones", Descripcion ="Subrubro Animaciones"},
                        new SubRubro { Nombre = "Diseño Grafico", Descripcion ="Subrubro Diseño Grafico"},
                        new SubRubro { Nombre = "Edicion de Video", Descripcion ="Subrubro Edicion de Video"}
                    }
                },
                new Rubro {Nombre = "Marketing y Ventas", Descripcion="Marketing y Ventas",
                    SubRubros = new List<SubRubro>{
                        new SubRubro { Nombre = "Publicidad", Descripcion ="Subrubro Publicidad"},
                        new SubRubro { Nombre = "Email Marketing", Descripcion ="Subrubro Email Marketing"}                        
                    }
                }

            };
            foreach (var item in listaRubros)
            {
                context.Rubros.Add(item);
            }
            #endregion

            #region semilla para la carga de empleadores

            var listaEmpleadores = new List<Empleador>{
                new Empleador{Cuit = "123", Rsocial="Empleador 1", Descripcion="Empleador de prueba 1"},
                new Empleador{Cuit = "456", Rsocial="Empleador 2", Descripcion="Empleador de prueba 2"},
                new Empleador{Cuit = "789", Rsocial="Empleador 3", Descripcion="Empleador de prueba 3"},
                new Empleador{Cuit = "444", Rsocial="Empleador 4", Descripcion="Empleador de prueba 4"},
            };

            foreach (var item in listaEmpleadores)
            {
                context.Empleadores.Add(item);
            }

            #endregion            

            base.Seed(context);
        }
    }
}
