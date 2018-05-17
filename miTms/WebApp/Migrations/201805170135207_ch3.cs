namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ch3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductName", c => c.String(maxLength: 150));
            AddColumn("dbo.Orders", "PodNo", c => c.String(maxLength: 20));
            AddColumn("dbo.Orders", "PodPhotographPath", c => c.String(maxLength: 120));
            AddColumn("dbo.Orders", "PodPhotograph", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PodPhotograph");
            DropColumn("dbo.Orders", "PodPhotographPath");
            DropColumn("dbo.Orders", "PodNo");
            DropColumn("dbo.Orders", "ProductName");
        }
    }
}
