namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TakeTicketFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "PriceType", c => c.String(maxLength: 1));
            AddColumn("dbo.Orders", "VehicleTypeRequirement", c => c.String(maxLength: 256));
            AddColumn("dbo.Orders", "VehicleLengthRequirement", c => c.String(maxLength: 256));
            AddColumn("dbo.Orders", "LoadTransportStationCode", c => c.String(maxLength: 16));
            AddColumn("dbo.Orders", "LoadTransportStationName", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "ReceiptTransportStationCode", c => c.String(maxLength: 16));
            AddColumn("dbo.Orders", "ReceiptTransportStationName", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "CargotypeClassificationCode", c => c.String(maxLength: 3));
            AddColumn("dbo.Orders", "PackageTypeCode", c => c.String(maxLength: 3));
            AddColumn("dbo.Orders", "MeasurementUnitCode", c => c.String(maxLength: 3));
            AddColumn("dbo.Orders", "VolumeMeasurementUnitCode", c => c.String(maxLength: 3));
            AddColumn("dbo.Orders", "BreakCartons", c => c.Int());
            AddColumn("dbo.Orders", "GoodsPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TotalMonetaryAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ResquestedLoadStartDatetime", c => c.DateTime());
            AddColumn("dbo.Orders", "ResquestedLoadEndDatetime", c => c.DateTime());
            AddColumn("dbo.Orders", "MobileTelephoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Orders", "PersonalIdentityTypeCode", c => c.String(maxLength: 3));
            AddColumn("dbo.Orders", "PersonalIdentityDocument", c => c.String(maxLength: 35));
            AddColumn("dbo.Orders", "ContractNumber", c => c.String(maxLength: 35));
            AddColumn("dbo.Orders", "RequestedInsuranceFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "InsuranceCompany", c => c.String(maxLength: 256));
            AddColumn("dbo.Orders", "InsuranceBillCode", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "InsuranceAccessAddress", c => c.String(maxLength: 256));
            AddColumn("dbo.Orders", "Consignee", c => c.String(maxLength: 256));
            AddColumn("dbo.Orders", "ConsiTelephoneNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.Orders", "ConsiMobileTelephoneNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.Orders", "ConsiCountrySubdivisionCode", c => c.String(maxLength: 12));
            AddColumn("dbo.Orders", "ConsiCountrySubdivisionName", c => c.String(maxLength: 70));
            AddColumn("dbo.Shippers", "ContactTelephoneNumber", c => c.String(maxLength: 18));
            AddColumn("dbo.Shippers", "PersonalIdentityDocument", c => c.String(maxLength: 35));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippers", "PersonalIdentityDocument");
            DropColumn("dbo.Shippers", "ContactTelephoneNumber");
            DropColumn("dbo.Orders", "ConsiCountrySubdivisionName");
            DropColumn("dbo.Orders", "ConsiCountrySubdivisionCode");
            DropColumn("dbo.Orders", "ConsiMobileTelephoneNumber");
            DropColumn("dbo.Orders", "ConsiTelephoneNumber");
            DropColumn("dbo.Orders", "Consignee");
            DropColumn("dbo.Orders", "InsuranceAccessAddress");
            DropColumn("dbo.Orders", "InsuranceBillCode");
            DropColumn("dbo.Orders", "InsuranceCompany");
            DropColumn("dbo.Orders", "RequestedInsuranceFlag");
            DropColumn("dbo.Orders", "ContractNumber");
            DropColumn("dbo.Orders", "PersonalIdentityDocument");
            DropColumn("dbo.Orders", "PersonalIdentityTypeCode");
            DropColumn("dbo.Orders", "MobileTelephoneNumber");
            DropColumn("dbo.Orders", "ResquestedLoadEndDatetime");
            DropColumn("dbo.Orders", "ResquestedLoadStartDatetime");
            DropColumn("dbo.Orders", "TotalMonetaryAmount");
            DropColumn("dbo.Orders", "GoodsPrice");
            DropColumn("dbo.Orders", "BreakCartons");
            DropColumn("dbo.Orders", "VolumeMeasurementUnitCode");
            DropColumn("dbo.Orders", "MeasurementUnitCode");
            DropColumn("dbo.Orders", "PackageTypeCode");
            DropColumn("dbo.Orders", "CargotypeClassificationCode");
            DropColumn("dbo.Orders", "ReceiptTransportStationName");
            DropColumn("dbo.Orders", "ReceiptTransportStationCode");
            DropColumn("dbo.Orders", "LoadTransportStationName");
            DropColumn("dbo.Orders", "LoadTransportStationCode");
            DropColumn("dbo.Orders", "VehicleLengthRequirement");
            DropColumn("dbo.Orders", "VehicleTypeRequirement");
            DropColumn("dbo.Orders", "PriceType");
            DropColumn("dbo.Orders", "TakeTicketFlag");
        }
    }
}
