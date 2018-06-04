namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test112 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ExternalNo", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ExternalNo", c => c.String(maxLength: 50));
        }
    }
}
