namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGarbaged_PurchaseBy_Requisition_RequisitionDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garbaged",
                c => new
                    {
                        GarbagedId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        CpuId = c.String(maxLength: 150),
                        DeviceId = c.String(maxLength: 150),
                        GarbagedDate = c.DateTime(nullable: false),
                        GarbagedBy = c.String(nullable: false, maxLength: 20),
                        GarbagedIp = c.String(nullable: false, maxLength: 30),
                        GarbagedEntryDate = c.DateTime(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GarbagedId)
                .ForeignKey("dbo.Employee", t => t.GarbagedBy, cascadeDelete: true)
                .Index(t => t.GarbagedId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.GarbagedBy);
            
            CreateTable(
                "dbo.PurchaseBy",
                c => new
                    {
                        PurchaseById = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Description = c.String(maxLength: 150),
                        Priority = c.Int(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseById)
                .Index(t => t.PurchaseById)
                .Index(t => t.QueryId, unique: true);
            
            CreateTable(
                "dbo.Requisition",
                c => new
                    {
                        RequisitionId = c.String(nullable: false, maxLength: 15),
                        QueryId = c.Guid(nullable: false, identity: true),
                        EmployeeId = c.String(maxLength: 20),
                        CampusId = c.String(maxLength: 10),
                        RoomNo = c.String(nullable: false, maxLength: 10),
                        FloorNo = c.String(nullable: false, maxLength: 10),
                        Remarks = c.String(maxLength: 150),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequisitionId)
                .ForeignKey("dbo.Campus", t => t.CampusId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.RequisitionId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CampusId);
            
            CreateTable(
                "dbo.RequisitionDetail",
                c => new
                    {
                        RequisitionDetailId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        RequisitionId = c.String(nullable: false, maxLength: 15),
                        ItemCode = c.String(nullable: false, maxLength: 20),
                        Quantity = c.Int(nullable: false),
                        ApprovedBy = c.String(nullable: false, maxLength: 10),
                        ApprovedDateTime = c.DateTime(nullable: false),
                        ApprovedIP = c.String(nullable: false),
                        IssuedBy = c.String(nullable: false),
                        IssuedDateTime = c.DateTime(nullable: false),
                        IssuedIP = c.String(nullable: false),
                        Remarks = c.String(maxLength: 10),
                        Status = c.String(maxLength: 10),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequisitionDetailId)
                .ForeignKey("dbo.Item", t => t.ItemCode, cascadeDelete: true)
                .ForeignKey("dbo.Requisition", t => t.RequisitionId, cascadeDelete: true)
                .Index(t => t.RequisitionDetailId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.RequisitionId)
                .Index(t => t.ItemCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequisitionDetail", "RequisitionId", "dbo.Requisition");
            DropForeignKey("dbo.RequisitionDetail", "ItemCode", "dbo.Item");
            DropForeignKey("dbo.Requisition", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Requisition", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Garbaged", "GarbagedBy", "dbo.Employee");
            DropIndex("dbo.RequisitionDetail", new[] { "ItemCode" });
            DropIndex("dbo.RequisitionDetail", new[] { "RequisitionId" });
            DropIndex("dbo.RequisitionDetail", new[] { "QueryId" });
            DropIndex("dbo.RequisitionDetail", new[] { "RequisitionDetailId" });
            DropIndex("dbo.Requisition", new[] { "CampusId" });
            DropIndex("dbo.Requisition", new[] { "EmployeeId" });
            DropIndex("dbo.Requisition", new[] { "QueryId" });
            DropIndex("dbo.Requisition", new[] { "RequisitionId" });
            DropIndex("dbo.PurchaseBy", new[] { "QueryId" });
            DropIndex("dbo.PurchaseBy", new[] { "PurchaseById" });
            DropIndex("dbo.Garbaged", new[] { "GarbagedBy" });
            DropIndex("dbo.Garbaged", new[] { "QueryId" });
            DropIndex("dbo.Garbaged", new[] { "GarbagedId" });
            DropTable("dbo.RequisitionDetail");
            DropTable("dbo.Requisition");
            DropTable("dbo.PurchaseBy");
            DropTable("dbo.Garbaged");
        }
    }
}
