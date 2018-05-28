namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addf11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LineOffers", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LineOffers", "Description");
        }
    }
}
