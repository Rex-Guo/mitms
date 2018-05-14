namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionHistories", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 7));
            AddColumn("dbo.TransactionHistories", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 7));
            AddColumn("dbo.TransactionHistories", "PhotographPath", c => c.String(maxLength: 50));
            AddColumn("dbo.TransactionHistories", "Photograph", c => c.Binary());
            AddColumn("dbo.TransactionHistories", "Remark2", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionHistories", "Remark2");
            DropColumn("dbo.TransactionHistories", "Photograph");
            DropColumn("dbo.TransactionHistories", "PhotographPath");
            DropColumn("dbo.TransactionHistories", "Latitude");
            DropColumn("dbo.TransactionHistories", "Longitude");
        }
    }
}
