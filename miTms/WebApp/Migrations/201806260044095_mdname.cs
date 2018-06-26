namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mdname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipOrderDetails", "LoadTransportStationName", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipOrderDetails", "ReceiptTransportStationName", c => c.String(maxLength: 50));
            DropColumn("dbo.ShipOrderDetails", "LoadTransportStation");
            DropColumn("dbo.ShipOrderDetails", "ReceiptTransportStation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShipOrderDetails", "ReceiptTransportStation", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipOrderDetails", "LoadTransportStation", c => c.String(maxLength: 50));
            DropColumn("dbo.ShipOrderDetails", "ReceiptTransportStationName");
            DropColumn("dbo.ShipOrderDetails", "LoadTransportStationName");
        }
    }
}
