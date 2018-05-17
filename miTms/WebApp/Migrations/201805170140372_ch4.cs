namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ch4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Orders", "Contact", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Contact");
            DropColumn("dbo.Orders", "PhoneNumber");
        }
    }
}
