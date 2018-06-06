namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ConsiContactName", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "ConsiAddress", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ConsiAddress");
            DropColumn("dbo.Orders", "ConsiContactName");
        }
    }
}
