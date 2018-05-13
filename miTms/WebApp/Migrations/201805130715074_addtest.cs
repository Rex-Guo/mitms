namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "InputUser", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "InputUser");
        }
    }
}
