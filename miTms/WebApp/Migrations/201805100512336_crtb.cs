namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crtb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ServiceUser = c.String(maxLength: 30),
                        TradeType = c.String(maxLength: 20),
                        LegalPerson = c.String(maxLength: 10),
                        RegistrationNumber = c.String(maxLength: 50),
                        LinkMan = c.String(maxLength: 30),
                        PhoneNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                        CustomerService = c.String(maxLength: 20),
                        Sales = c.String(maxLength: 20),
                        Payment = c.String(maxLength: 20),
                        PaymentDays = c.Int(),
                        BankName = c.String(maxLength: 50),
                        BankAccount = c.String(maxLength: 50),
                        InvoiceTitle = c.String(maxLength: 50),
                        PaymentNumber = c.String(maxLength: 50),
                        CompanyId = c.Int(nullable: false),
                        Address = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(maxLength: 20),
                        ExternalNo = c.String(maxLength: 20),
                        OrderDate = c.DateTime(),
                        Location1 = c.String(maxLength: 120),
                        Location2 = c.String(maxLength: 120),
                        Requirements = c.String(maxLength: 120),
                        PlanDeliveryDate = c.DateTime(),
                        TimePeriod = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        PlateNumber = c.String(nullable: false, maxLength: 10),
                        Driver = c.String(maxLength: 20),
                        DriverPhone = c.String(maxLength: 50),
                        Packages = c.Int(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Volume = c.Decimal(precision: 18, scale: 2),
                        Cartons = c.Int(),
                        Pallets = c.Int(),
                        Status = c.String(maxLength: 20),
                        DeliveryDate = c.DateTime(),
                        CloseDate = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.PlateNumber, unique: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(maxLength: 20),
                        ExternalNo = c.String(maxLength: 20),
                        UsingDate = c.DateTime(),
                        Location1 = c.String(maxLength: 120),
                        Location2 = c.String(maxLength: 120),
                        Requirements = c.String(maxLength: 120),
                        PlateNumber = c.String(nullable: false, maxLength: 10),
                        PlateNumberPosition = c.String(nullable: false, maxLength: 10),
                        VehStatus = c.String(nullable: false, maxLength: 20),
                        CarType = c.String(nullable: false, maxLength: 20),
                        VehicleType = c.String(maxLength: 20),
                        VehicleProperty = c.String(nullable: false, maxLength: 20),
                        CompanyId = c.Int(nullable: false),
                        Axles = c.Int(),
                        ECOMark = c.String(nullable: false),
                        StrLoadWeight = c.Int(),
                        LoadWeight = c.Int(),
                        LoadVolume = c.Int(),
                        CarriageSize = c.Decimal(precision: 18, scale: 2),
                        Driver = c.String(nullable: false, maxLength: 20),
                        DriverPhone = c.String(nullable: false, maxLength: 50),
                        AssistantDriver = c.String(maxLength: 20),
                        AssistantDriverPhone = c.String(maxLength: 50),
                        VehLongSize = c.Decimal(precision: 18, scale: 2),
                        CubicleType = c.String(maxLength: 20),
                        VehUseType = c.String(maxLength: 20),
                        CustomsNo = c.String(maxLength: 20),
                        VehUse = c.String(maxLength: 20),
                        AVGECON = c.Decimal(precision: 18, scale: 2),
                        AVGECONScale = c.Decimal(precision: 18, scale: 2),
                        RoadKM = c.Decimal(precision: 18, scale: 2),
                        RoadHours = c.Decimal(precision: 18, scale: 2),
                        RoadKMScale = c.Decimal(precision: 18, scale: 2),
                        GPSDeviceId = c.String(maxLength: 50),
                        Owner = c.String(maxLength: 20),
                        OwnerContactPhone = c.String(maxLength: 50),
                        Brand = c.String(maxLength: 20),
                        RPM = c.Int(),
                        PurchasedDate = c.DateTime(),
                        PurchasedAmount = c.Decimal(precision: 18, scale: 2),
                        VehLong = c.Decimal(precision: 18, scale: 2),
                        VehWide = c.Decimal(precision: 18, scale: 2),
                        VehHigh = c.Decimal(precision: 18, scale: 2),
                        VIN = c.String(maxLength: 50),
                        ServiceLife = c.Int(),
                        MaintainKM = c.Int(),
                        MaintainDate = c.DateTime(),
                        MaintainMonth = c.Int(),
                        ExistVehTailBoard = c.Boolean(nullable: false),
                        VehTailBoardBrand = c.String(maxLength: 30),
                        VehTailBoardFactory = c.String(maxLength: 30),
                        VehTailBoardLife = c.Int(),
                        VehTailBoardAmount = c.Decimal(precision: 18, scale: 2),
                        VehTailBoardGPSDeviceId = c.String(maxLength: 50),
                        DrLicenseModel = c.String(maxLength: 50),
                        DrLicenseUseNature = c.String(maxLength: 50),
                        DrLicenseBrand = c.String(maxLength: 50),
                        DrLicenseDevId = c.String(maxLength: 50),
                        DrLicenseEngineId = c.String(maxLength: 50),
                        DrLicenseRegistrationDate = c.DateTime(),
                        DrLicensePubDate = c.DateTime(),
                        DrLicenseRatedUsers = c.Int(),
                        DrLicenseVehWeight = c.Decimal(precision: 18, scale: 2),
                        DrLicenseDevWeight = c.Decimal(precision: 18, scale: 2),
                        DrLicenseNetWeight = c.Decimal(precision: 18, scale: 2),
                        DrLicenseNetVolume = c.Decimal(precision: 18, scale: 2),
                        DrLicenseVehWide = c.Decimal(precision: 18, scale: 2),
                        DrLicenseVehHigh = c.Decimal(precision: 18, scale: 2),
                        DrLicenseVehLong = c.Decimal(precision: 18, scale: 2),
                        DrLicenseScrapedDate = c.DateTime(),
                        LoLicenseManageId = c.String(maxLength: 50),
                        LoLicenseId = c.String(maxLength: 50),
                        LoLicenseBusinessScope = c.String(maxLength: 50),
                        LoLicensePubDate = c.DateTime(),
                        LoLicenseValidDate = c.DateTime(),
                        LoLicenseCheckDate = c.DateTime(),
                        LoLicensePlace = c.String(maxLength: 30),
                        InsTrafficPolicyId = c.String(maxLength: 50),
                        InsTrafficPolicyCompany = c.String(maxLength: 50),
                        InsTrafficPolicyVaildateDate = c.String(maxLength: 50),
                        InsTrafficPolicyAmount = c.Decimal(precision: 18, scale: 2),
                        InsThirdPartyId = c.String(maxLength: 50),
                        InsThirdPartyVaildateDate = c.DateTime(),
                        InsThirdPartyAmount = c.Decimal(precision: 18, scale: 2),
                        InsThirdPartyLogisticsAmount = c.Decimal(precision: 18, scale: 2),
                        InsThirdPartyLogisticsVaildateDate = c.DateTime(),
                        Status = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.PlateNumber, unique: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.Vehicle", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Orders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customer", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Vehicle", new[] { "CompanyId" });
            DropIndex("dbo.Vehicle", new[] { "PlateNumber" });
            DropIndex("dbo.Orders", new[] { "CompanyId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "PlateNumber" });
            DropIndex("dbo.Orders", new[] { "VehicleId" });
            DropIndex("dbo.Customer", new[] { "CompanyId" });
            DropIndex("dbo.Customer", new[] { "Name" });
            DropTable("dbo.Vehicle");
            DropTable("dbo.Orders");
            DropTable("dbo.Customer");
        }
    }
}
