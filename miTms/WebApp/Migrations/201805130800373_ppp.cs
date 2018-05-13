namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "Packages", c => c.Int());
            AddColumn("dbo.Vehicle", "Weight", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Vehicle", "Volume", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Vehicle", "Cartons", c => c.Int());
            AddColumn("dbo.Vehicle", "Pallets", c => c.Int());
            AddColumn("dbo.Vehicle", "InputUser", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "InputUser");
            DropColumn("dbo.Vehicle", "Pallets");
            DropColumn("dbo.Vehicle", "Cartons");
            DropColumn("dbo.Vehicle", "Volume");
            DropColumn("dbo.Vehicle", "Weight");
            DropColumn("dbo.Vehicle", "Packages");
        }
    }
}
