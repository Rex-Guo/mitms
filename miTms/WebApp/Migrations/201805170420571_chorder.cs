namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.Orders", new[] { "VehicleId" });
            AlterColumn("dbo.Orders", "VehicleId", c => c.Int());
            AlterColumn("dbo.Orders", "PlateNumber", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "VehicleId");
            AddForeignKey("dbo.Orders", "VehicleId", "dbo.Vehicle", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.Orders", new[] { "VehicleId" });
            AlterColumn("dbo.Orders", "PlateNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "VehicleId");
            AddForeignKey("dbo.Orders", "VehicleId", "dbo.Vehicle", "Id", cascadeDelete: true);
        }
    }
}
