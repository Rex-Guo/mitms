namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adpass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipOrders", "PassLocation", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipOrders", "PassLocation");
        }
    }
}
