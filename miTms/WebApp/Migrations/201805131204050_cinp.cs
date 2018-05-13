namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cinp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicle", "InputUser", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "InputUser", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
