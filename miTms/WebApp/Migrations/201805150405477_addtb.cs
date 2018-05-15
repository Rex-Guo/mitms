namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Project = c.String(maxLength: 20),
                        Location1 = c.String(maxLength: 50),
                        Location2 = c.String(maxLength: 50),
                        TimeLimit = c.String(maxLength: 20),
                        VehicleType = c.String(maxLength: 20),
                        PiceType = c.String(maxLength: 20),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 520),
                        InputUser = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LineOffers");
        }
    }
}
