namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtrans : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(maxLength: 20),
                        PlateNumber = c.String(maxLength: 10),
                        Status = c.String(maxLength: 20),
                        TransactioDateTime = c.DateTime(nullable: false),
                        Remark = c.String(maxLength: 120),
                        Flag1 = c.Int(nullable: false),
                        Flag2 = c.Int(nullable: false),
                        InputUser = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicle", "CustomerId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "CustomerId");
            DropTable("dbo.TransactionHistories");
        }
    }
}
