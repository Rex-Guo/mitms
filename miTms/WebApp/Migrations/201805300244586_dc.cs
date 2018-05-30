namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Customer", new[] { "Name" });
            DropIndex("dbo.Customer", new[] { "CompanyId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AddColumn("dbo.Orders", "ShipperId", c => c.Int());
            CreateIndex("dbo.Orders", "ShipperId");
            AddForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers", "Id");
            DropColumn("dbo.Orders", "CustomerId");
            DropTable("dbo.Customer");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            DropColumn("dbo.Orders", "ShipperId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Customer", "CompanyId");
            CreateIndex("dbo.Customer", "Name", unique: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customer", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
