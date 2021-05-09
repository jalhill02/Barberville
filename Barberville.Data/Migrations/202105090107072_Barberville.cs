namespace Barberville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Barberville : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Service = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ShopId = c.Int(nullable: false),
                        BarberId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Barber", t => t.BarberId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.shop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId)
                .Index(t => t.BarberId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Barber",
                c => new
                    {
                        BarberId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarberId)
                .ForeignKey("dbo.shop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.shop",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ShopName = c.String(nullable: false),
                        ShopLocation = c.String(nullable: false),
                        Services = c.String(),
                    })
                .PrimaryKey(t => t.ShopId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            DropTable("dbo.Note");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.NoteId);
            
            DropForeignKey("dbo.Appointment", "ShopId", "dbo.shop");
            DropForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Appointment", "BarberId", "dbo.Barber");
            DropForeignKey("dbo.Barber", "ShopId", "dbo.shop");
            DropIndex("dbo.Barber", new[] { "ShopId" });
            DropIndex("dbo.Appointment", new[] { "CustomerId" });
            DropIndex("dbo.Appointment", new[] { "BarberId" });
            DropIndex("dbo.Appointment", new[] { "ShopId" });
            DropTable("dbo.Customer");
            DropTable("dbo.shop");
            DropTable("dbo.Barber");
            DropTable("dbo.Appointment");
        }
    }
}
