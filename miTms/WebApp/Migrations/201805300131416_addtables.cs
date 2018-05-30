namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Type = c.Int(nullable: false),
                        ContactName = c.String(nullable: false, maxLength: 50),
                        ContactMobileTelephoneNumber = c.String(nullable: false, maxLength: 18),
                        RegisteredAddress = c.String(maxLength: 256),
                        PermitNumber = c.String(nullable: false, maxLength: 50),
                        CountrySubdivisionCode = c.String(nullable: false, maxLength: 12),
                        RegisteredCapital = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnifiedSocialCreditldentifier = c.String(maxLength: 18),
                        BusinessScope = c.String(maxLength: 256),
                        CompanyId = c.Int(nullable: false),
                        RegistrationDatetime = c.DateTime(nullable: false),
                        UpdateTimeDatetime = c.DateTime(),
                        IsBlaclkList = c.Boolean(nullable: false),
                        IsDeleteFlag = c.Boolean(nullable: false),
                        SynchronizationTime = c.DateTime(),
                        IsException = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Gender = c.Int(nullable: false),
                        IdentityDocumentNumber = c.String(maxLength: 18),
                        MobileTelephoneNumber = c.String(maxLength: 18),
                        TelephoneNumber = c.String(maxLength: 18),
                        QualificationCertificateNumber = c.String(maxLength: 19),
                        Remark = c.String(maxLength: 512),
                        Carrierid = c.Int(nullable: false),
                        RegistrationDatetime = c.DateTime(nullable: false),
                        UpdateTimeDatetime = c.DateTime(),
                        IsBlaclkList = c.Boolean(nullable: false),
                        IsDeleteFlag = c.Boolean(nullable: false),
                        SynchronizationTime = c.DateTime(),
                        IsException = c.Boolean(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.Carrierid, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.Carrierid)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Type = c.Int(nullable: false),
                        ContactName = c.String(nullable: false, maxLength: 50),
                        ContactIdCard = c.String(nullable: false, maxLength: 18),
                        ContactMobileTelephoneNumber = c.String(nullable: false, maxLength: 18),
                        RegisteredAddress = c.String(maxLength: 256),
                        RegisteredCapital = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnifiedSocialCreditldentifier = c.String(maxLength: 18),
                        UnifiedsocialDatetime = c.DateTime(),
                        CompanyId = c.Int(nullable: false),
                        RegistrationDatetime = c.DateTime(nullable: false),
                        UpdateTimeDatetime = c.DateTime(),
                        IsBlaclkList = c.Boolean(nullable: false),
                        IsDeleteFlag = c.Boolean(nullable: false),
                        SynchronizationTime = c.DateTime(),
                        IsException = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shippers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Drivers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Drivers", "Carrierid", "dbo.Carriers");
            DropForeignKey("dbo.Carriers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Shippers", new[] { "CompanyId" });
            DropIndex("dbo.Drivers", new[] { "CompanyId" });
            DropIndex("dbo.Drivers", new[] { "Carrierid" });
            DropIndex("dbo.Carriers", new[] { "CompanyId" });
            DropTable("dbo.Shippers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Carriers");
        }
    }
}
