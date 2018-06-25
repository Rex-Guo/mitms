namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mdshiporder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipOrderDetails", "ShipOrderNo", c => c.String(maxLength: 20));
            AddColumn("dbo.ShipOrders", "ShipOrderNo", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.ShipOrders", "OrderNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShipOrders", "OrderNo", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.ShipOrders", "ShipOrderNo");
            DropColumn("dbo.ShipOrderDetails", "ShipOrderNo");
        }
    }
}
