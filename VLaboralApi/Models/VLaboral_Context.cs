using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using VlaboralApi.Infrastructure;

namespace VLaboralApi.Models
{
    public class VLaboral_Context : IdentityDbContext<ApplicationUser> // DbContext
    {
        public VLaboral_Context() : base("VLaboral_Context", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            //fpaz: configuracion para el llenado inicial de la base de datos            
            //Database.SetInitializer<VLaboral_Context>(new VLaboralDB_Initializer());
            //Database.SetInitializer<VLaboral_Context>(new DropCreateDatabaseIfModelChanges<VLaboral_Context>());
  
        }

        #region Definicion de Tablas DbSet
        
        public System.Data.Entity.DbSet<VLaboralApi.Models.Empleado> Empleados { get; set; }        
        public System.Data.Entity.DbSet<VLaboralApi.Models.Empleador> Empleadores { get; set; }
        public System.Data.Entity.DbSet<VLaboralApi.Models.Rubro> Rubros { get; set; }
        public System.Data.Entity.DbSet<VLaboralApi.Models.SubRubro> SubRubros { get; set; }        

        public System.Data.Entity.DbSet<VLaboralApi.Models.Puesto> Puestos { get; set; }

        public System.Data.Entity.DbSet<VLaboralApi.Models.Oferta> Ofertas { get; set; }

        #endregion

        public static VLaboral_Context Create()
        {
            return new VLaboral_Context();
        }

       
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    //fpaz: para relacion 1 a 1 entre cliente y cuenta corriente defino que ClienteId va a ser la ForeingKey de la relacion 1 a 1 y asi poder usar el properti cliente para navegacion
        //    //fpaz: agregar en srpints siguientes
        //    //modelBuilder.Entity<Empleado>()
        //    //            .HasRequired(a => a.Curriculum)
        //    //            .WithMany()
        //    //            .HasForeignKey(u => u.CurriculumId);

        //    ////iafar: relacion 1 a 1 con puestos y requisitos
        //    //// Configure StudentId as PK for StudentAddress
        //    //modelBuilder.Entity<Requisito>()
        //    //    .HasKey(e => e.Id);

        //    //// Configure StudentId as FK for StudentAddress
        //    //modelBuilder.Entity<Puesto>()
        //    //            .HasOptional(s => s.Requisito) // Mark StudentAddress is optional for Student
        //    //            .WithRequired(ad => ad.Puesto); // Create inverse relationship


        //    //iafar: Relacion 1..0,1 entre Puesto y Requisito 
        //    //Configuro Id de Puesto como PK para Requisito
        //    //modelBuilder.Entity<Requisito>()
        //    //    .HasKey(e => e.Id);

        //    //Configuro el id de Puesto como FK para Requisito
        //    //modelBuilder.Entity<Puesto>()
        //    //            .HasOptional(s => s.Requisito) // El requisito es opcional para Puesto
        //    //            .WithRequired(ad => ad.Puesto); // Se crea la relacion inversa de 
        //    //Requisito con puesto, esta define que idPuesto sea Fk/PK para Requisito (1 o ninguno)



        //    base.OnModelCreating(modelBuilder);
        //}

        
        
    }

  


#region Definicion de semillas  

    //public class VLaboralDB_Initializer:DropCreateDatabaseAlways<VLaboral_Context>
    //{
    //    protected override void Seed(VLaboral_Context context)
    //    {
    //        var empleado = new Empleado
    //        {
    //            NombreApellido = "Emp1",
    //            Direccion = "Calle Falsa 123",
    //            FecNacimiento=DateTime.Now
    //        };
    //        context.Empleados.Add(empleado);

    //        // fpaz: semillas para llenado inicial de base de datos
    //        #region carga rubros y subrubros

    //        var listaRubros = new List<Rubro>{
    //            new Rubro {Nombre = "Informatica", Descripcion="Rubro Informatica",
    //                SubRubros = new List<SubRubro>{
    //                    new SubRubro { Nombre = "Administracion de Sistemas", Descripcion ="Subrubro Admin de sistemas"},
    //                    new SubRubro { Nombre = "Desarrollo de Software", Descripcion ="Subrubro Desarrollo de Software"},
    //                    new SubRubro { Nombre = "Soporte Tecnico", Descripcion ="Subrubro Soporte Tecnico"}
    //                }
    //            },
    //            new Rubro {Nombre = "Diseño y Multimedia", Descripcion="Rubro Diseño y Multimedia",
    //                SubRubros = new List<SubRubro>{
    //                    new SubRubro { Nombre = "Animaciones", Descripcion ="Subrubro Animaciones"},
    //                    new SubRubro { Nombre = "Diseño Grafico", Descripcion ="Subrubro Diseño Grafico"},
    //                    new SubRubro { Nombre = "Edicion de Video", Descripcion ="Subrubro Edicion de Video"}
    //                }
    //            },
    //            new Rubro {Nombre = "Marketing y Ventas", Descripcion="Marketing y Ventas",
    //                SubRubros = new List<SubRubro>{
    //                    new SubRubro { Nombre = "Publicidad", Descripcion ="Subrubro Publicidad"},
    //                    new SubRubro { Nombre = "Email Marketing", Descripcion ="Subrubro Email Marketing"}                        
    //                }
    //            }

    //        };
    //        foreach (var item in listaRubros)
    //        {
    //            context.Rubros.Add(item);
    //        }
    //        #endregion
    //        #region semilla para la carga de empleadores

    //        var listaEmpleadores = new List<Empleador>{
    //            new Empleador{Cuit = "123", Rsocial="Empleador 1", Descripcion="Empleador de prueba 1"},
    //            new Empleador{Cuit = "456", Rsocial="Empleador 2", Descripcion="Empleador de prueba 2"},
    //            new Empleador{Cuit = "789", Rsocial="Empleador 3", Descripcion="Empleador de prueba 3"},
    //            new Empleador{Cuit = "444", Rsocial="Empleador 4", Descripcion="Empleador de prueba 4"},
    //        };

    //        foreach (var item in listaEmpleadores)
    //        {
    //            context.Empleadores.Add(item);
    //        }

    //        #endregion
    //        #region semilla para la carga de ofertas

    //        //var listaOfertas = new List<Oferta>
    //        //{
    //        //    new Oferta {
    //        //        Nombre="Oferta 1",
    //        //        Lugar= "Santiago del Estero",
    //        //        FechaInicioConvocatoria = Convert.ToDateTime("25/08/2015"),
    //        //        FechaFinConvocatoria   = Convert.ToDateTime("14/11/2015"),
    //        //        Publico = true,
    //        //        Descripcion="Oferta de prueba 1",
    //        //        Estado="Abierta",
    //        //        EmpleadorId = listaEmpleadores[1].Id ,
    //        //        Puestos = new List<Puesto>{ //alta de puestos
    //        //            new Puesto {
    //        //                Nombre ="Puesto 1 - Ofeta 1",
    //        //                CantidadDeVacantes=3,
    //        //                Remuneracion=3000,
    //        //                SubRubros = new List<SubRubro>{
    //        //                    new SubRubro {Id = listaRubros[0].SubRubros.FirstOrDefault().Id}
    //        //                }
    //        //            }
    //        //            //,
    //        //            //new Puesto {
    //        //            //    Nombre ="Puesto 2 - Ofeta 1",
    //        //            //    CantidadDeVacantes=3,
    //        //            //    Remuneracion=3000,
    //        //            //    SubRubros = new List<SubRubro>{
    //        //            //        new SubRubro {Id = listaRubros[1].SubRubros.FirstOrDefault().Id}
    //        //            //    }
    //        //            //}
    //        //        }

    //        //    }
    //        //};

    //        //foreach (var item in listaOfertas)
    //        //{
    //        //    context.Ofertas.Add(item);
    //        //}
    //        #endregion

    //        base.Seed(context);
    //    }
    //}
    #endregion

}

