namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "UsingDate", c => c.DateTime());
            DropColumn("dbo.Vehicle", "UseingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "UseingDate", c => c.DateTime());
            DropColumn("dbo.Vehicle", "UsingDate");
        }
    }
}
