namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ccs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "ShipperId", c => c.Int());
            AddColumn("dbo.Vehicle", "CarrierId", c => c.Int());
            CreateIndex("dbo.Vehicle", "CarrierId");
            AddForeignKey("dbo.Vehicle", "CarrierId", "dbo.Carriers", "Id");
            DropColumn("dbo.Vehicle", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "CustomerId", c => c.Int());
            DropForeignKey("dbo.Vehicle", "CarrierId", "dbo.Carriers");
            DropIndex("dbo.Vehicle", new[] { "CarrierId" });
            DropColumn("dbo.Vehicle", "CarrierId");
            DropColumn("dbo.Vehicle", "ShipperId");
        }
    }
}
