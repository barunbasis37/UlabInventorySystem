namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckInAndCheckInDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckIn",
                c => new
                    {
                        CheckInId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        CategoryId = c.String(maxLength: 10),
                        InvoiceNo = c.String(maxLength: 150),
                        PurchaseDate = c.DateTime(nullable: false),
                        TotalBillAmount = c.Decimal(nullable: false, storeType: "money"),
                        Comment = c.String(maxLength: 150),
                        ReceiptNo = c.String(nullable: false, maxLength: 100),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CheckInId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CheckInId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CheckInDetail",
                c => new
                    {
                        CheckInDetailId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        AuditCode = c.String(maxLength: 250),
                        CpuCode = c.String(nullable: false, maxLength: 250),
                        DeviceCode = c.String(nullable: false, maxLength: 250),
                        CheckInId = c.String(maxLength: 20),
                        ItemCodeId = c.String(maxLength: 20),
                        ItemModel = c.String(nullable: false, maxLength: 50),
                        ItemSize = c.String(nullable: false, maxLength: 50),
                        ItemBrand = c.String(nullable: false, maxLength: 50),
                        Unitprice = c.Decimal(nullable: false, storeType: "money"),
                        WarrantyExpireDate = c.DateTime(nullable: false),
                        ProductSerialNo = c.String(nullable: false, maxLength: 50),
                        ItemStatus = c.String(nullable: false, maxLength: 50),
                        CurrentStatus = c.String(nullable: false, maxLength: 50),
                        Remarks = c.String(maxLength: 150),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CheckInDetailId)
                .ForeignKey("dbo.CheckIn", t => t.CheckInId)
                .ForeignKey("dbo.Item", t => t.ItemCodeId)
                .Index(t => t.CheckInDetailId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.AuditCode, unique: true)
                .Index(t => t.CpuCode, name: "IX_CPUCode")
                .Index(t => t.DeviceCode, unique: true)
                .Index(t => t.CheckInId)
                .Index(t => t.ItemCodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInDetail", "ItemCodeId", "dbo.Item");
            DropForeignKey("dbo.CheckInDetail", "CheckInId", "dbo.CheckIn");
            DropForeignKey("dbo.CheckIn", "CategoryId", "dbo.Category");
            DropIndex("dbo.CheckInDetail", new[] { "ItemCodeId" });
            DropIndex("dbo.CheckInDetail", new[] { "CheckInId" });
            DropIndex("dbo.CheckInDetail", new[] { "DeviceCode" });
            DropIndex("dbo.CheckInDetail", "IX_CPUCode");
            DropIndex("dbo.CheckInDetail", new[] { "AuditCode" });
            DropIndex("dbo.CheckInDetail", new[] { "QueryId" });
            DropIndex("dbo.CheckInDetail", new[] { "CheckInDetailId" });
            DropIndex("dbo.CheckIn", new[] { "CategoryId" });
            DropIndex("dbo.CheckIn", new[] { "QueryId" });
            DropIndex("dbo.CheckIn", new[] { "CheckInId" });
            DropTable("dbo.CheckInDetail");
            DropTable("dbo.CheckIn");
        }
    }
}
