namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tch1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "PlateNumber" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Orders", "PlateNumber", unique: true);
        }
    }
}
