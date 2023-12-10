namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase2342017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 30),
                        DateTime = c.DateTime(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        PriorityLevel = c.Int(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Campus_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.Campus_Id)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Campus_Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        DepartmentShortCode = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 50),
                        SchoolId = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        Description = c.String(maxLength: 100),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name)
                .Index(t => t.SchoolId)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        EmployeeId = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 150),
                        Designation = c.String(nullable: false),
                        DepartmentId = c.Guid(),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(nullable: false, maxLength: 100),
                        Priority = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 150),
                        Priority = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Guid(),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CheckIn",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        CategoryId = c.Guid(),
                        InvoiceNo = c.String(maxLength: 150),
                        SupplierId = c.Guid(),
                        PurchaseDate = c.DateTime(nullable: false),
                        TotalBillAmount = c.Decimal(nullable: false, storeType: "money"),
                        Comment = c.String(maxLength: 150),
                        PurchaseBy = c.String(nullable: false, maxLength: 20),
                        ReceiptNo = c.String(nullable: false, maxLength: 100),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Supplier", t => t.SupplierId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.CheckInDetails",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        CpuCode = c.Int(nullable: false),
                        DeviceCode = c.Int(nullable: false),
                        CheckInId = c.Guid(),
                        ItemCodeId = c.Guid(),
                        ItemModel = c.String(nullable: false, maxLength: 50),
                        ItemSize = c.String(nullable: false, maxLength: 50),
                        ItemBrand = c.String(nullable: false, maxLength: 50),
                        Unitprice = c.Decimal(nullable: false, storeType: "money"),
                        WarrantyExpireDate = c.DateTime(nullable: false),
                        ProductSerialNo = c.String(nullable: false, maxLength: 50),
                        ItemStatus = c.String(nullable: false, maxLength: 50),
                        CurrentStatus = c.String(nullable: false, maxLength: 50),
                        Remarks = c.String(maxLength: 150),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckIn", t => t.CheckInId)
                .ForeignKey("dbo.Item", t => t.ItemCodeId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.CpuCode, unique: true, name: "IX_CPUCode")
                .Index(t => t.DeviceCode, unique: true)
                .Index(t => t.CheckInId)
                .Index(t => t.ItemCodeId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Priority = c.Int(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubCategoryId = c.Guid(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.ItemDetails",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        ItemId = c.Guid(nullable: false),
                        Model = c.String(nullable: false, maxLength: 50),
                        Size = c.String(nullable: false, maxLength: 50),
                        Brand = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Details = c.String(maxLength: 500),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.ItemId)
                .Index(t => t.Model)
                .Index(t => t.Size)
                .Index(t => t.Brand);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 500),
                        Priority = c.Int(nullable: false),
                        CategoryId = c.Guid(),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Garbaged",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        CpuId = c.Guid(),
                        DeviceId = c.Guid(nullable: false),
                        GarbagedDate = c.DateTime(nullable: false),
                        GarbagedBy = c.Guid(nullable: false),
                        GarbagedIp = c.String(nullable: false, maxLength: 30),
                        GarbagedEntryDate = c.DateTime(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckInDetails", t => t.DeviceId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.GarbagedBy, cascadeDelete: true)
                .ForeignKey("dbo.CheckInDetails", t => t.CpuId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.CpuId)
                .Index(t => t.DeviceId)
                .Index(t => t.GarbagedBy);
            
            CreateTable(
                "dbo.Issue",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        EmployeeId = c.Guid(),
                        DepartmentId = c.Guid(),
                        CampusId = c.Guid(),
                        Floor = c.String(nullable: false),
                        Room = c.String(nullable: false),
                        IssueRemark = c.String(maxLength: 100),
                        ReturnRemark = c.String(maxLength: 100),
                        ApprovedId = c.String(nullable: false, maxLength: 30),
                        ApprovedDateTime = c.DateTime(nullable: false),
                        ApprovedIp = c.String(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CampusId)
                .Index(t => t.IssueRemark, unique: true)
                .Index(t => t.ReturnRemark, unique: true);
            
            CreateTable(
                "dbo.IssueDetail",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        IssueId = c.Guid(nullable: false),
                        CpuId = c.Guid(),
                        DeviceId = c.Guid(),
                        AgainstDeviceCode = c.String(maxLength: 50),
                        CurrentStatus = c.String(maxLength: 150),
                        DeviceReturnRemarks = c.String(maxLength: 150),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        ReturnComment = c.String(maxLength: 150),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckInDetails", t => t.DeviceId)
                .ForeignKey("dbo.CheckInDetails", t => t.CpuId)
                .ForeignKey("dbo.Issue", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.IssueId)
                .Index(t => t.CpuId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.PurchaseBy",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        Name = c.String(maxLength: 150),
                        Description = c.String(maxLength: 150),
                        Priority = c.Int(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.Requisition",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        EmployeeId = c.Guid(),
                        CampusID = c.Guid(),
                        RoomNo = c.String(nullable: false, maxLength: 10),
                        FloorNo = c.String(nullable: false, maxLength: 10),
                        Remarks = c.String(maxLength: 150),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CampusID);
            
            CreateTable(
                "dbo.RequisitionDetails",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"),
                        RequisitionId = c.Guid(nullable: false),
                        ItemCode = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ApprovedBy = c.String(nullable: false, maxLength: 10),
                        ApprovedDateTime = c.DateTime(nullable: false),
                        ApprovedIP = c.String(nullable: false),
                        IssuedBy = c.String(nullable: false),
                        IssuedDateTime = c.DateTime(nullable: false),
                        IssuedIP = c.String(nullable: false),
                        Remarks = c.String(maxLength: 10),
                        Status = c.String(maxLength: 10),
                        PostedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        PostedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedIp = c.String(nullable: false, maxLength: 50, defaultValueSql: "NEWID()"),
                        UpdatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemCode, cascadeDelete: true)
                .ForeignKey("dbo.Requisition", t => t.RequisitionId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.RequisitionId)
                .Index(t => t.ItemCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequisitionDetails", "RequisitionId", "dbo.Requisition");
            DropForeignKey("dbo.RequisitionDetails", "ItemCode", "dbo.Item");
            DropForeignKey("dbo.Requisition", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Requisition", "CampusID", "dbo.Campus");
            DropForeignKey("dbo.IssueDetail", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails");
            DropForeignKey("dbo.IssueDetail", "DeviceId", "dbo.CheckInDetails");
            DropForeignKey("dbo.Issue", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Issue", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Issue", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Garbaged", "CpuId", "dbo.CheckInDetails");
            DropForeignKey("dbo.Garbaged", "GarbagedBy", "dbo.Employee");
            DropForeignKey("dbo.Garbaged", "DeviceId", "dbo.CheckInDetails");
            DropForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Supplier", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CheckInDetails", "ItemCodeId", "dbo.Item");
            DropForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.ItemDetails", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CheckInDetails", "CheckInId", "dbo.CheckIn");
            DropForeignKey("dbo.CheckIn", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.School", "Campus_Id", "dbo.Campus");
            DropForeignKey("dbo.Department", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.RequisitionDetails", new[] { "ItemCode" });
            DropIndex("dbo.RequisitionDetails", new[] { "RequisitionId" });
            DropIndex("dbo.RequisitionDetails", new[] { "Id" });
            DropIndex("dbo.Requisition", new[] { "CampusID" });
            DropIndex("dbo.Requisition", new[] { "EmployeeId" });
            DropIndex("dbo.Requisition", new[] { "Id" });
            DropIndex("dbo.PurchaseBy", new[] { "Id" });
            DropIndex("dbo.IssueDetail", new[] { "DeviceId" });
            DropIndex("dbo.IssueDetail", new[] { "CpuId" });
            DropIndex("dbo.IssueDetail", new[] { "IssueId" });
            DropIndex("dbo.IssueDetail", new[] { "Id" });
            DropIndex("dbo.Issue", new[] { "ReturnRemark" });
            DropIndex("dbo.Issue", new[] { "IssueRemark" });
            DropIndex("dbo.Issue", new[] { "CampusId" });
            DropIndex("dbo.Issue", new[] { "DepartmentId" });
            DropIndex("dbo.Issue", new[] { "EmployeeId" });
            DropIndex("dbo.Issue", new[] { "Id" });
            DropIndex("dbo.Garbaged", new[] { "GarbagedBy" });
            DropIndex("dbo.Garbaged", new[] { "DeviceId" });
            DropIndex("dbo.Garbaged", new[] { "CpuId" });
            DropIndex("dbo.Garbaged", new[] { "Id" });
            DropIndex("dbo.Supplier", new[] { "CategoryId" });
            DropIndex("dbo.Supplier", new[] { "Id" });
            DropIndex("dbo.ItemDetails", new[] { "Brand" });
            DropIndex("dbo.ItemDetails", new[] { "Size" });
            DropIndex("dbo.ItemDetails", new[] { "Model" });
            DropIndex("dbo.ItemDetails", new[] { "ItemId" });
            DropIndex("dbo.ItemDetails", new[] { "Id" });
            DropIndex("dbo.Item", new[] { "SubCategoryId" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.Item", new[] { "Name" });
            DropIndex("dbo.Item", new[] { "Id" });
            DropIndex("dbo.CheckInDetails", new[] { "ItemCodeId" });
            DropIndex("dbo.CheckInDetails", new[] { "CheckInId" });
            DropIndex("dbo.CheckInDetails", new[] { "DeviceCode" });
            DropIndex("dbo.CheckInDetails", "IX_CPUCode");
            DropIndex("dbo.CheckInDetails", new[] { "Id" });
            DropIndex("dbo.CheckIn", new[] { "SupplierId" });
            DropIndex("dbo.CheckIn", new[] { "CategoryId" });
            DropIndex("dbo.CheckIn", new[] { "Id" });
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropIndex("dbo.SubCategory", new[] { "Id" });
            DropIndex("dbo.Category", new[] { "Id" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "Name" });
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.Department", new[] { "Type" });
            DropIndex("dbo.Department", new[] { "SchoolId" });
            DropIndex("dbo.Department", new[] { "Name" });
            DropIndex("dbo.Department", new[] { "Id" });
            DropIndex("dbo.School", new[] { "Campus_Id" });
            DropIndex("dbo.School", new[] { "Name" });
            DropIndex("dbo.School", new[] { "Id" });
            DropIndex("dbo.Campus", new[] { "Name" });
            DropIndex("dbo.Campus", new[] { "Id" });
            DropTable("dbo.RequisitionDetails");
            DropTable("dbo.Requisition");
            DropTable("dbo.PurchaseBy");
            DropTable("dbo.IssueDetail");
            DropTable("dbo.Issue");
            DropTable("dbo.Garbaged");
            DropTable("dbo.Supplier");
            DropTable("dbo.ItemDetails");
            DropTable("dbo.Item");
            DropTable("dbo.CheckInDetails");
            DropTable("dbo.CheckIn");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Category");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.School");
            DropTable("dbo.Campus");
        }
    }
}
