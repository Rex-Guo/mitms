namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carriers", "Description", c => c.String(maxLength: 512));
            AddColumn("dbo.Carriers", "LogoPicture", c => c.String(maxLength: 256));
            AddColumn("dbo.Drivers", "Description", c => c.String(maxLength: 512));
            AddColumn("dbo.Drivers", "LogoPicture", c => c.String(maxLength: 256));
            AddColumn("dbo.Shippers", "Description", c => c.String(maxLength: 512));
            AddColumn("dbo.Shippers", "LogoPicture", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippers", "LogoPicture");
            DropColumn("dbo.Shippers", "Description");
            DropColumn("dbo.Drivers", "LogoPicture");
            DropColumn("dbo.Drivers", "Description");
            DropColumn("dbo.Carriers", "LogoPicture");
            DropColumn("dbo.Carriers", "Description");
        }
    }
}
