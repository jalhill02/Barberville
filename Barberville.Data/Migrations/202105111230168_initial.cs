namespace Barberville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointment", "Service", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointment", "Service", c => c.String(nullable: false));
        }
    }
}
