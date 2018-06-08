namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cfk : DbMigration
    {
        public override void Up()
        {
        
           
          
            CreateIndex("dbo.LineQuotes", "CompanyId");
            AddForeignKey("dbo.LineQuotes", "CompanyId", "dbo.Companies", "Id", cascadeDelete: false);
           
        }
        
        public override void Down()
        {
           
        }
    }
}
