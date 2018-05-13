namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorderid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "OrderId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "OrderId");
        }
    }
}
