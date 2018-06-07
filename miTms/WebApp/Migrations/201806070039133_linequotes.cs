namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linequotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineQuotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Location1 = c.String(nullable: false, maxLength: 50),
                        Location2 = c.String(nullable: false, maxLength: 50),
                        TimePeriod = c.Int(nullable: false),
                        PiceVehicleType = c.String(maxLength: 20),
                        PiceType = c.String(maxLength: 20),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 520),
                        Description = c.String(),
                        InputUser = c.String(maxLength: 20),
                        CarrierId = c.Int(),
                        CompanyId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.CarrierId)
                .ForeignKey("dbo.Companies", t => t.CarrierId)
                .Index(t => t.CarrierId);
            
            DropTable("dbo.LineOffers");
        }
        
        public override void Down()
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
                        Description = c.String(),
                        InputUser = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.LineQuotes", "CarrierId", "dbo.Companies");
            DropForeignKey("dbo.LineQuotes", "CarrierId", "dbo.Carriers");
            DropIndex("dbo.LineQuotes", new[] { "CarrierId" });
            DropTable("dbo.LineQuotes");
        }
    }
}
