namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dcd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            AlterColumn("dbo.Orders", "ShipperId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ShipperId");
            AddForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            AlterColumn("dbo.Orders", "ShipperId", c => c.Int());
            CreateIndex("dbo.Orders", "ShipperId");
            AddForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers", "Id");
        }
    }
}
