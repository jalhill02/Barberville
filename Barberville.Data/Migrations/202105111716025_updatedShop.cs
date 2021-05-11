namespace Barberville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedShop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.shop", "BarberName", c => c.String());
            AddColumn("dbo.shop", "Services", c => c.String());
            AddColumn("dbo.shop", "CreatedUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.shop", "CreatedUtc");
            DropColumn("dbo.shop", "Services");
            DropColumn("dbo.shop", "BarberName");
        }
    }
}
