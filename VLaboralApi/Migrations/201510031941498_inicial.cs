namespace VLaboralApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cuit = c.String(),
                        Rsocial = c.String(),
                        Dir = c.String(),
                        Tel = c.String(),
                        Mail = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Level = c.Byte(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        EmpleadorId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadors", t => t.EmpleadorId, cascadeDelete: true)
                .Index(t => t.EmpleadorId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Ofertas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Lugar = c.String(),
                        FechaInicioConvocatoria = c.DateTime(nullable: false),
                        FechaFinConvocatoria = c.DateTime(nullable: false),
                        Publico = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.String(),
                        EmpleadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadors", t => t.EmpleadorId, cascadeDelete: true)
                .Index(t => t.EmpleadorId);
            
            CreateTable(
                "dbo.Puestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CantidadDeVacantes = c.Int(nullable: false),
                        Remuneracion = c.Int(nullable: false),
                        OfertaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ofertas", t => t.OfertaId, cascadeDelete: true)
                .Index(t => t.OfertaId);
            
            CreateTable(
                "dbo.SubRubroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        RubroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rubroes", t => t.RubroId, cascadeDelete: true)
                .Index(t => t.RubroId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dni = c.Int(nullable: false),
                        Cuil = c.String(),
                        NombreApellido = c.String(),
                        FecNacimiento = c.DateTime(nullable: false),
                        Email = c.String(),
                        Direccion = c.String(),
                        ResumenCurricular = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rubroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SubRubroEmpleadors",
                c => new
                    {
                        SubRubro_Id = c.Int(nullable: false),
                        Empleador_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubRubro_Id, t.Empleador_Id })
                .ForeignKey("dbo.SubRubroes", t => t.SubRubro_Id, cascadeDelete: true)
                .ForeignKey("dbo.Empleadors", t => t.Empleador_Id, cascadeDelete: true)
                .Index(t => t.SubRubro_Id)
                .Index(t => t.Empleador_Id);
            
            CreateTable(
                "dbo.EmpleadoSubRubroes",
                c => new
                    {
                        Empleado_Id = c.Int(nullable: false),
                        SubRubro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Empleado_Id, t.SubRubro_Id })
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubRubroes", t => t.SubRubro_Id, cascadeDelete: true)
                .Index(t => t.Empleado_Id)
                .Index(t => t.SubRubro_Id);
            
            CreateTable(
                "dbo.SubRubroPuestoes",
                c => new
                    {
                        SubRubro_Id = c.Int(nullable: false),
                        Puesto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubRubro_Id, t.Puesto_Id })
                .ForeignKey("dbo.SubRubroes", t => t.SubRubro_Id, cascadeDelete: true)
                .ForeignKey("dbo.Puestoes", t => t.Puesto_Id, cascadeDelete: true)
                .Index(t => t.SubRubro_Id)
                .Index(t => t.Puesto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SubRubroes", "RubroId", "dbo.Rubroes");
            DropForeignKey("dbo.SubRubroPuestoes", "Puesto_Id", "dbo.Puestoes");
            DropForeignKey("dbo.SubRubroPuestoes", "SubRubro_Id", "dbo.SubRubroes");
            DropForeignKey("dbo.EmpleadoSubRubroes", "SubRubro_Id", "dbo.SubRubroes");
            DropForeignKey("dbo.EmpleadoSubRubroes", "Empleado_Id", "dbo.Empleadoes");
            DropForeignKey("dbo.SubRubroEmpleadors", "Empleador_Id", "dbo.Empleadors");
            DropForeignKey("dbo.SubRubroEmpleadors", "SubRubro_Id", "dbo.SubRubroes");
            DropForeignKey("dbo.Puestoes", "OfertaId", "dbo.Ofertas");
            DropForeignKey("dbo.Ofertas", "EmpleadorId", "dbo.Empleadors");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "EmpleadorId", "dbo.Empleadors");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SubRubroPuestoes", new[] { "Puesto_Id" });
            DropIndex("dbo.SubRubroPuestoes", new[] { "SubRubro_Id" });
            DropIndex("dbo.EmpleadoSubRubroes", new[] { "SubRubro_Id" });
            DropIndex("dbo.EmpleadoSubRubroes", new[] { "Empleado_Id" });
            DropIndex("dbo.SubRubroEmpleadors", new[] { "Empleador_Id" });
            DropIndex("dbo.SubRubroEmpleadors", new[] { "SubRubro_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubRubroes", new[] { "RubroId" });
            DropIndex("dbo.Puestoes", new[] { "OfertaId" });
            DropIndex("dbo.Ofertas", new[] { "EmpleadorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "EmpleadorId" });
            DropTable("dbo.SubRubroPuestoes");
            DropTable("dbo.EmpleadoSubRubroes");
            DropTable("dbo.SubRubroEmpleadors");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rubroes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.SubRubroes");
            DropTable("dbo.Puestoes");
            DropTable("dbo.Ofertas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Empleadors");
        }
    }
}
