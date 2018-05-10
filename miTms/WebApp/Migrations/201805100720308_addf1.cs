namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addf1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "TimePeriod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "TimePeriod");
        }
    }
}
