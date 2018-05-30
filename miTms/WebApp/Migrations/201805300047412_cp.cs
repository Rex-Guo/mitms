namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "RegisteredCapital", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Companies", "UnifiedSocialCreditldentifier", c => c.String(nullable: false, maxLength: 18));
            AddColumn("dbo.Companies", "UnifiedSocialDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "BusinessScope", c => c.String(nullable: false, maxLength: 512));
            AddColumn("dbo.Companies", "BusinessLicenseStartDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "BusinessLicenseendDatetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "CountrySubdivisionCode", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Companies", "PermitNumber", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Companies", "LegalPersonName", c => c.String(nullable: false, maxLength: 18));
            AddColumn("dbo.Companies", "LegalPersonTelehoneNumber", c => c.String(nullable: false, maxLength: 18));
            AddColumn("dbo.Companies", "ContactName", c => c.String(nullable: false, maxLength: 18));
            AddColumn("dbo.Companies", "ContactMobileTelephoneNumber", c => c.String(nullable: false, maxLength: 18));
            AddColumn("dbo.Companies", "FaxNumber", c => c.String(maxLength: 18));
            AddColumn("dbo.Companies", "InternetPlusProperty", c => c.String(maxLength: 18));
            AddColumn("dbo.Companies", "IsDeleteFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Companies", "SynchronizationTime", c => c.DateTime());
            AddColumn("dbo.Companies", "IsException", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Companies", "Address", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Companies", "City");
            DropColumn("dbo.Companies", "Province");
            DropColumn("dbo.Companies", "RegisterDate");
            DropColumn("dbo.Companies", "Employees");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Employees", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "Province", c => c.String());
            AddColumn("dbo.Companies", "City", c => c.String());
            AlterColumn("dbo.Companies", "Address", c => c.String(maxLength: 60));
            AlterColumn("dbo.Companies", "Name", c => c.String());
            DropColumn("dbo.Companies", "IsException");
            DropColumn("dbo.Companies", "SynchronizationTime");
            DropColumn("dbo.Companies", "IsDeleteFlag");
            DropColumn("dbo.Companies", "InternetPlusProperty");
            DropColumn("dbo.Companies", "FaxNumber");
            DropColumn("dbo.Companies", "ContactMobileTelephoneNumber");
            DropColumn("dbo.Companies", "ContactName");
            DropColumn("dbo.Companies", "LegalPersonTelehoneNumber");
            DropColumn("dbo.Companies", "LegalPersonName");
            DropColumn("dbo.Companies", "PermitNumber");
            DropColumn("dbo.Companies", "CountrySubdivisionCode");
            DropColumn("dbo.Companies", "BusinessLicenseendDatetime");
            DropColumn("dbo.Companies", "BusinessLicenseStartDatetime");
            DropColumn("dbo.Companies", "BusinessScope");
            DropColumn("dbo.Companies", "UnifiedSocialDatetime");
            DropColumn("dbo.Companies", "UnifiedSocialCreditldentifier");
            DropColumn("dbo.Companies", "RegisteredCapital");
        }
    }
}
