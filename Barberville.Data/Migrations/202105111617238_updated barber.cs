namespace Barberville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbarber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barber", "FullName", c => c.String());
            AddColumn("dbo.Barber", "ShopName", c => c.String());
            AddColumn("dbo.Barber", "Services", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Barber", "Services");
            DropColumn("dbo.Barber", "ShopName");
            DropColumn("dbo.Barber", "FullName");
        }
    }
}
