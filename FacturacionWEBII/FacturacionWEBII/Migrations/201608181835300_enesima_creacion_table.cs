namespace FacturacionWEBII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enesima_creacion_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Fecha_Nacimiento = c.DateTime(nullable: false),
                        Dirección = c.String(nullable: false),
                        Estado_Civil = c.String(),
                        Fecha_Ingreso = c.DateTime(nullable: false),
                        TipoClient = c.String(),
                        Descuento = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IdFactura = c.Int(nullable: false, identity: true),
                        FechaFactura = c.DateTime(nullable: false),
                        IdCliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdFactura)
                .ForeignKey("dbo.Clientes", t => t.IdCliente_Id)
                .Index(t => t.IdCliente_Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Marca = c.String(),
                        Familia = c.String(nullable: false),
                        Fabricante = c.String(nullable: false),
                        Tipo_Unidad = c.String(nullable: false),
                        Departamento = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Fecha_Ingreso = c.DateTime(nullable: false),
                        Unidad = c.String(),
                        Impuesto = c.Single(nullable: false),
                        Factura_IdFactura = c.Int(),
                        Factura_IdFactura1 = c.Int(),
                        Inventario_IdInvent = c.Int(),
                        Inventario_IdInvent1 = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Facturas", t => t.Factura_IdFactura)
                .ForeignKey("dbo.Facturas", t => t.Factura_IdFactura1)
                .ForeignKey("dbo.Inventarios", t => t.Inventario_IdInvent)
                .ForeignKey("dbo.Inventarios", t => t.Inventario_IdInvent1)
                .Index(t => t.Factura_IdFactura)
                .Index(t => t.Factura_IdFactura1)
                .Index(t => t.Inventario_IdInvent)
                .Index(t => t.Inventario_IdInvent1);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        IdInvent = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Cantidad_Mínima = c.Int(nullable: false),
                        Cantidad_Máxima = c.Int(nullable: false),
                        Gravado_Excepto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdInvent);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Productoes", "Inventario_IdInvent1", "dbo.Inventarios");
            DropForeignKey("dbo.Productoes", "Inventario_IdInvent", "dbo.Inventarios");
            DropForeignKey("dbo.Productoes", "Factura_IdFactura1", "dbo.Facturas");
            DropForeignKey("dbo.Productoes", "Factura_IdFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "IdCliente_Id", "dbo.Clientes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Productoes", new[] { "Inventario_IdInvent1" });
            DropIndex("dbo.Productoes", new[] { "Inventario_IdInvent" });
            DropIndex("dbo.Productoes", new[] { "Factura_IdFactura1" });
            DropIndex("dbo.Productoes", new[] { "Factura_IdFactura" });
            DropIndex("dbo.Facturas", new[] { "IdCliente_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Productoes");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}
