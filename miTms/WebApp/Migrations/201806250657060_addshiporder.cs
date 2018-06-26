namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshiporder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(maxLength: 20),
                        OrderId = c.Int(nullable: false),
                        Location1 = c.String(maxLength: 120),
                        LoadTransportStationName = c.String(maxLength: 50),
                        Location2 = c.String(maxLength: 120),
                        ReceiptTransportStationName = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        Packages = c.Int(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Volume = c.Decimal(precision: 18, scale: 2),
                        Pallets = c.Int(),
                        Cartons = c.Int(),
                        BreakCartons = c.Int(),
                        ShipOrderId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.ShipOrders", t => t.ShipOrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ShipOrderId);
            
            CreateTable(
                "dbo.ShipOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(nullable: false, maxLength: 20),
                        ExternalNo = c.String(maxLength: 30),
                        OrderDate = c.DateTime(nullable: false),
                        BusinessType = c.String(maxLength: 8),
                        Status = c.Int(nullable: false),
                        CarrierId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CarType = c.String(maxLength: 20),
                        Driver = c.String(maxLength: 30),
                        DriverPhone = c.String(maxLength: 18),
                        ContractNumber = c.String(maxLength: 35),
                        TotalMonetaryAmount = c.Decimal(precision: 18, scale: 2),
                        Remark = c.String(maxLength: 255),
                        Location1 = c.String(maxLength: 120),
                        Location2 = c.String(maxLength: 120),
                        Requirements = c.String(maxLength: 120),
                        TimePeriod = c.Int(nullable: false),
                        PlanDepartDate = c.DateTime(),
                        PlanDeliveryDate = c.DateTime(),
                        DepartDate = c.DateTime(),
                        DeliveryDate = c.DateTime(),
                        ClosedDate = c.DateTime(),
                        ItemCount = c.Int(nullable: false),
                        Packages = c.Int(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Volume = c.Decimal(precision: 18, scale: 2),
                        Pallets = c.Int(),
                        Cartons = c.Int(),
                        BreakCartons = c.Int(),
                        InputUser = c.String(nullable: false, maxLength: 20),
                        CompanyId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.CarrierId, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: false)
                .Index(t => t.CarrierId)
                .Index(t => t.VehicleId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipOrderDetails", "ShipOrderId", "dbo.ShipOrders");
            DropForeignKey("dbo.ShipOrders", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.ShipOrders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ShipOrders", "CarrierId", "dbo.Carriers");
            DropForeignKey("dbo.ShipOrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.ShipOrders", new[] { "CompanyId" });
            DropIndex("dbo.ShipOrders", new[] { "VehicleId" });
            DropIndex("dbo.ShipOrders", new[] { "CarrierId" });
            DropIndex("dbo.ShipOrderDetails", new[] { "ShipOrderId" });
            DropIndex("dbo.ShipOrderDetails", new[] { "OrderId" });
            DropTable("dbo.ShipOrders");
            DropTable("dbo.ShipOrderDetails");
        }
    }
}
