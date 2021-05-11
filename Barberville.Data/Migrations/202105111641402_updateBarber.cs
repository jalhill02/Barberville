namespace Barberville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBarber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barber", "ShopLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Barber", "ShopLocation");
        }
    }
}
