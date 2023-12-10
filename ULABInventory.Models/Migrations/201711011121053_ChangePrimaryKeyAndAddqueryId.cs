namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePrimaryKeyAndAddqueryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.School", "Campus_Id", "dbo.Campus");
            DropForeignKey("dbo.Issue", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Requisition", "CampusID", "dbo.Campus");
            DropForeignKey("dbo.Department", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Issue", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Garbaged", "GarbagedBy", "dbo.Employee");
            DropForeignKey("dbo.Issue", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Requisition", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CheckIn", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Supplier", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.CheckInDetails", "CheckInId", "dbo.CheckIn");
            DropForeignKey("dbo.Garbaged", "DeviceId", "dbo.CheckInDetails");
            DropForeignKey("dbo.Garbaged", "CpuId", "dbo.CheckInDetails");
            DropForeignKey("dbo.ItemDetails", "ItemId", "dbo.Item");
            DropForeignKey("dbo.CheckInDetails", "ItemCodeId", "dbo.Item");
            DropForeignKey("dbo.RequisitionDetails", "ItemCode", "dbo.Item");
            DropForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.IssueDetail", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.RequisitionDetails", "RequisitionId", "dbo.Requisition");
            DropIndex("dbo.Campus", new[] { "Id" });
            DropIndex("dbo.School", new[] { "Id" });
            DropIndex("dbo.School", new[] { "Campus_Id" });
            DropIndex("dbo.Department", new[] { "Id" });
            DropIndex("dbo.Department", new[] { "SchoolId" });
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Category", new[] { "Id" });
            DropIndex("dbo.SubCategory", new[] { "Id" });
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropIndex("dbo.CheckIn", new[] { "Id" });
            DropIndex("dbo.CheckIn", new[] { "CategoryId" });
            DropIndex("dbo.CheckIn", new[] { "SupplierId" });
            DropIndex("dbo.CheckInDetails", new[] { "Id" });
            DropIndex("dbo.CheckInDetails", new[] { "CheckInId" });
            DropIndex("dbo.CheckInDetails", new[] { "ItemCodeId" });
            DropIndex("dbo.Item", new[] { "Id" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.Item", new[] { "SubCategoryId" });
            DropIndex("dbo.ItemDetails", new[] { "Id" });
            DropIndex("dbo.ItemDetails", new[] { "ItemId" });
            DropIndex("dbo.Supplier", new[] { "Id" });
            DropIndex("dbo.Supplier", new[] { "CategoryId" });
            DropIndex("dbo.Garbaged", new[] { "Id" });
            DropIndex("dbo.Garbaged", new[] { "CpuId" });
            DropIndex("dbo.Garbaged", new[] { "DeviceId" });
            DropIndex("dbo.Garbaged", new[] { "GarbagedBy" });
            DropIndex("dbo.Issue", new[] { "Id" });
            DropIndex("dbo.Issue", new[] { "EmployeeId" });
            DropIndex("dbo.Issue", new[] { "DepartmentId" });
            DropIndex("dbo.Issue", new[] { "CampusId" });
            DropIndex("dbo.IssueDetail", new[] { "Id" });
            DropIndex("dbo.IssueDetail", new[] { "IssueId" });
            DropIndex("dbo.PurchaseBy", new[] { "Id" });
            DropIndex("dbo.Requisition", new[] { "Id" });
            DropIndex("dbo.Requisition", new[] { "EmployeeId" });
            DropIndex("dbo.Requisition", new[] { "CampusID" });
            DropIndex("dbo.RequisitionDetails", new[] { "Id" });
            DropIndex("dbo.RequisitionDetails", new[] { "RequisitionId" });
            DropIndex("dbo.RequisitionDetails", new[] { "ItemCode" });
            RenameColumn(table: "dbo.School", name: "Campus_Id", newName: "Campus_CampusId");
            DropPrimaryKey("dbo.Campus");
            DropPrimaryKey("dbo.School");
            DropPrimaryKey("dbo.Department");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.SubCategory");
            DropPrimaryKey("dbo.CheckIn");
            DropPrimaryKey("dbo.CheckInDetails");
            DropPrimaryKey("dbo.Item");
            DropPrimaryKey("dbo.ItemDetails");
            DropPrimaryKey("dbo.Supplier");
            DropPrimaryKey("dbo.Garbaged");
            DropPrimaryKey("dbo.Issue");
            DropPrimaryKey("dbo.IssueDetail");
            DropPrimaryKey("dbo.PurchaseBy");
            DropPrimaryKey("dbo.Requisition");
            DropPrimaryKey("dbo.RequisitionDetails");
            AddColumn("dbo.Campus", "CampusId", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Campus", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.School", "SchoolId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.School", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Department", "DepartmentId", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Department", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Employee", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Category", "CategoryId", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Category", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.SubCategory", "SubCategoryId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.SubCategory", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.CheckIn", "CheckInId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.CheckIn", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.CheckInDetails", "CheckInDetailId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.CheckInDetails", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Item", "ItemId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Item", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.ItemDetails", "ItemDetailId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.ItemDetails", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Supplier", "SupplierId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Supplier", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Garbaged", "GarbagedId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Garbaged", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Issue", "IssueId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Issue", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.IssueDetail", "IssueDetailId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.IssueDetail", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.PurchaseBy", "PurchaseById", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.PurchaseBy", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Requisition", "RequisitionId", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Requisition", "QueryId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.RequisitionDetails", "RequisitionDetailId", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.RequisitionDetails", "QueryId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.School", "Campus_CampusId", c => c.String(maxLength: 10));
            AlterColumn("dbo.Department", "SchoolId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "EmployeeId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "DepartmentId", c => c.String(maxLength: 10));
            AlterColumn("dbo.SubCategory", "CategoryId", c => c.String(maxLength: 10));
            AlterColumn("dbo.CheckIn", "CategoryId", c => c.String(maxLength: 10));
            AlterColumn("dbo.CheckIn", "SupplierId", c => c.String(maxLength: 20));
            AlterColumn("dbo.CheckInDetails", "CheckInId", c => c.String(maxLength: 20));
            AlterColumn("dbo.CheckInDetails", "ItemCodeId", c => c.String(maxLength: 20));
            AlterColumn("dbo.Item", "CategoryId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Item", "SubCategoryId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ItemDetails", "ItemId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Supplier", "CategoryId", c => c.String(maxLength: 10));
            AlterColumn("dbo.Garbaged", "CpuId", c => c.String(maxLength: 20));
            AlterColumn("dbo.Garbaged", "DeviceId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Garbaged", "GarbagedBy", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Issue", "EmployeeId", c => c.String(maxLength: 20));
            AlterColumn("dbo.Issue", "DepartmentId", c => c.String(maxLength: 10));
            AlterColumn("dbo.Issue", "CampusId", c => c.String(maxLength: 10));
            AlterColumn("dbo.IssueDetail", "IssueId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Requisition", "EmployeeId", c => c.String(maxLength: 20));
            AlterColumn("dbo.Requisition", "CampusId", c => c.String(maxLength: 10));
            AlterColumn("dbo.RequisitionDetails", "RequisitionId", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.RequisitionDetails", "ItemCode", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Campus", "CampusId");
            AddPrimaryKey("dbo.School", "SchoolId");
            AddPrimaryKey("dbo.Department", "DepartmentId");
            AddPrimaryKey("dbo.Employee", "EmployeeId");
            AddPrimaryKey("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.SubCategory", "SubCategoryId");
            AddPrimaryKey("dbo.CheckIn", "CheckInId");
            AddPrimaryKey("dbo.CheckInDetails", "CheckInDetailId");
            AddPrimaryKey("dbo.Item", "ItemId");
            AddPrimaryKey("dbo.ItemDetails", "ItemDetailId");
            AddPrimaryKey("dbo.Supplier", "SupplierId");
            AddPrimaryKey("dbo.Garbaged", "GarbagedId");
            AddPrimaryKey("dbo.Issue", "IssueId");
            AddPrimaryKey("dbo.IssueDetail", "IssueDetailId");
            AddPrimaryKey("dbo.PurchaseBy", "PurchaseById");
            AddPrimaryKey("dbo.Requisition", "RequisitionId");
            AddPrimaryKey("dbo.RequisitionDetails", "RequisitionDetailId");
            CreateIndex("dbo.Campus", "CampusId");
            CreateIndex("dbo.Campus", "QueryId", unique: true);
            CreateIndex("dbo.School", "SchoolId");
            CreateIndex("dbo.School", "QueryId", unique: true);
            CreateIndex("dbo.School", "Campus_CampusId");
            CreateIndex("dbo.Department", "DepartmentId");
            CreateIndex("dbo.Department", "QueryId", unique: true);
            CreateIndex("dbo.Department", "SchoolId");
            CreateIndex("dbo.Employee", "QueryId", unique: true);
            CreateIndex("dbo.Employee", "EmployeeId", unique: true, name: "IX_Id");
            CreateIndex("dbo.Employee", "DepartmentId");
            CreateIndex("dbo.Category", "CategoryId");
            CreateIndex("dbo.Category", "QueryId", unique: true);
            CreateIndex("dbo.SubCategory", "SubCategoryId", name: "IX_SubcategoryId");
            CreateIndex("dbo.SubCategory", "QueryId", unique: true);
            CreateIndex("dbo.SubCategory", "CategoryId");
            CreateIndex("dbo.CheckIn", "CheckInId");
            CreateIndex("dbo.CheckIn", "QueryId", unique: true);
            CreateIndex("dbo.CheckIn", "CategoryId");
            CreateIndex("dbo.CheckIn", "SupplierId");
            CreateIndex("dbo.CheckInDetails", "CheckInDetailId");
            CreateIndex("dbo.CheckInDetails", "QueryId", unique: true);
            CreateIndex("dbo.CheckInDetails", "CheckInId");
            CreateIndex("dbo.CheckInDetails", "ItemCodeId");
            CreateIndex("dbo.Item", "ItemId");
            CreateIndex("dbo.Item", "QueryId", unique: true);
            CreateIndex("dbo.Item", "CategoryId");
            CreateIndex("dbo.Item", "SubCategoryId");
            CreateIndex("dbo.ItemDetails", "ItemDetailId");
            CreateIndex("dbo.ItemDetails", "QueryId", unique: true);
            CreateIndex("dbo.ItemDetails", "ItemId");
            CreateIndex("dbo.Supplier", "SupplierId");
            CreateIndex("dbo.Supplier", "QueryId", unique: true);
            CreateIndex("dbo.Supplier", "CategoryId");
            CreateIndex("dbo.Garbaged", "GarbagedId");
            CreateIndex("dbo.Garbaged", "QueryId", unique: true);
            CreateIndex("dbo.Garbaged", "CpuId");
            CreateIndex("dbo.Garbaged", "DeviceId");
            CreateIndex("dbo.Garbaged", "GarbagedBy");
            CreateIndex("dbo.Issue", "IssueId");
            CreateIndex("dbo.Issue", "QueryId", unique: true);
            CreateIndex("dbo.Issue", "EmployeeId");
            CreateIndex("dbo.Issue", "DepartmentId");
            CreateIndex("dbo.Issue", "CampusId");
            CreateIndex("dbo.IssueDetail", "IssueDetailId");
            CreateIndex("dbo.IssueDetail", "QueryId", unique: true);
            CreateIndex("dbo.IssueDetail", "IssueId");
            CreateIndex("dbo.PurchaseBy", "PurchaseById");
            CreateIndex("dbo.PurchaseBy", "QueryId", unique: true);
            CreateIndex("dbo.Requisition", "RequisitionId");
            CreateIndex("dbo.Requisition", "QueryId", unique: true);
            CreateIndex("dbo.Requisition", "EmployeeId");
            CreateIndex("dbo.Requisition", "CampusId");
            CreateIndex("dbo.RequisitionDetails", "RequisitionDetailId");
            CreateIndex("dbo.RequisitionDetails", "QueryId", unique: true);
            CreateIndex("dbo.RequisitionDetails", "RequisitionId");
            CreateIndex("dbo.RequisitionDetails", "ItemCode");
            AddForeignKey("dbo.School", "Campus_CampusId", "dbo.Campus", "CampusId");
            AddForeignKey("dbo.Issue", "CampusId", "dbo.Campus", "CampusId");
            AddForeignKey("dbo.Requisition", "CampusId", "dbo.Campus", "CampusId");
            AddForeignKey("dbo.Department", "SchoolId", "dbo.School", "SchoolId", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.Issue", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.Garbaged", "GarbagedBy", "dbo.Employee", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Issue", "EmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.Requisition", "EmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.CheckIn", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Item", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Supplier", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory", "SubCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.CheckInDetails", "CheckInId", "dbo.CheckIn", "CheckInId");
            AddForeignKey("dbo.Garbaged", "DeviceId", "dbo.CheckInDetails", "CheckInDetailId", cascadeDelete: true);
            AddForeignKey("dbo.Garbaged", "CpuId", "dbo.CheckInDetails", "CheckInDetailId");
            AddForeignKey("dbo.ItemDetails", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
            AddForeignKey("dbo.CheckInDetails", "ItemCodeId", "dbo.Item", "ItemId");
            AddForeignKey("dbo.RequisitionDetails", "ItemCode", "dbo.Item", "ItemId", cascadeDelete: true);
            AddForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier", "SupplierId");
            AddForeignKey("dbo.IssueDetail", "IssueId", "dbo.Issue", "IssueId", cascadeDelete: true);
            AddForeignKey("dbo.RequisitionDetails", "RequisitionId", "dbo.Requisition", "RequisitionId", cascadeDelete: true);
            DropColumn("dbo.Campus", "Code");
            DropColumn("dbo.Campus", "Id");
            DropColumn("dbo.School", "Code");
            DropColumn("dbo.School", "Id");
            DropColumn("dbo.Department", "Code");
            DropColumn("dbo.Department", "Id");
            DropColumn("dbo.Department", "DepartmentShortCode");
            DropColumn("dbo.Employee", "Code");
            DropColumn("dbo.Employee", "Id");
            DropColumn("dbo.Category", "Code");
            DropColumn("dbo.Category", "Id");
            DropColumn("dbo.SubCategory", "Code");
            DropColumn("dbo.SubCategory", "Id");
            DropColumn("dbo.CheckIn", "Code");
            DropColumn("dbo.CheckIn", "Id");
            DropColumn("dbo.CheckIn", "PurchaseBy");
            DropColumn("dbo.CheckInDetails", "Code");
            DropColumn("dbo.CheckInDetails", "Id");
            DropColumn("dbo.Item", "Code");
            DropColumn("dbo.Item", "Id");
            DropColumn("dbo.ItemDetails", "Code");
            DropColumn("dbo.ItemDetails", "Id");
            DropColumn("dbo.Supplier", "Code");
            DropColumn("dbo.Supplier", "Id");
            DropColumn("dbo.Garbaged", "Code");
            DropColumn("dbo.Garbaged", "Id");
            DropColumn("dbo.Issue", "Code");
            DropColumn("dbo.Issue", "Id");
            DropColumn("dbo.IssueDetail", "Code");
            DropColumn("dbo.IssueDetail", "Id");
            DropColumn("dbo.PurchaseBy", "Code");
            DropColumn("dbo.PurchaseBy", "Id");
            DropColumn("dbo.Requisition", "Code");
            DropColumn("dbo.Requisition", "Id");
            DropColumn("dbo.RequisitionDetails", "Code");
            DropColumn("dbo.RequisitionDetails", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequisitionDetails", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.RequisitionDetails", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Requisition", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Requisition", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PurchaseBy", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.PurchaseBy", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.IssueDetail", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.IssueDetail", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Issue", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Issue", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Garbaged", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Garbaged", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Supplier", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Supplier", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ItemDetails", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.ItemDetails", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Item", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Item", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CheckInDetails", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.CheckInDetails", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CheckIn", "PurchaseBy", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.CheckIn", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.CheckIn", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SubCategory", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.SubCategory", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Category", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Category", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employee", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Employee", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Department", "DepartmentShortCode", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Department", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Department", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.School", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.School", "Code", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Campus", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Campus", "Code", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RequisitionDetails", "RequisitionId", "dbo.Requisition");
            DropForeignKey("dbo.IssueDetail", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.RequisitionDetails", "ItemCode", "dbo.Item");
            DropForeignKey("dbo.CheckInDetails", "ItemCodeId", "dbo.Item");
            DropForeignKey("dbo.ItemDetails", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Garbaged", "CpuId", "dbo.CheckInDetails");
            DropForeignKey("dbo.Garbaged", "DeviceId", "dbo.CheckInDetails");
            DropForeignKey("dbo.CheckInDetails", "CheckInId", "dbo.CheckIn");
            DropForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.Supplier", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CheckIn", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Requisition", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Issue", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Garbaged", "GarbagedBy", "dbo.Employee");
            DropForeignKey("dbo.Issue", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Requisition", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Issue", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.School", "Campus_CampusId", "dbo.Campus");
            DropIndex("dbo.RequisitionDetails", new[] { "ItemCode" });
            DropIndex("dbo.RequisitionDetails", new[] { "RequisitionId" });
            DropIndex("dbo.RequisitionDetails", new[] { "QueryId" });
            DropIndex("dbo.RequisitionDetails", new[] { "RequisitionDetailId" });
            DropIndex("dbo.Requisition", new[] { "CampusId" });
            DropIndex("dbo.Requisition", new[] { "EmployeeId" });
            DropIndex("dbo.Requisition", new[] { "QueryId" });
            DropIndex("dbo.Requisition", new[] { "RequisitionId" });
            DropIndex("dbo.PurchaseBy", new[] { "QueryId" });
            DropIndex("dbo.PurchaseBy", new[] { "PurchaseById" });
            DropIndex("dbo.IssueDetail", new[] { "IssueId" });
            DropIndex("dbo.IssueDetail", new[] { "QueryId" });
            DropIndex("dbo.IssueDetail", new[] { "IssueDetailId" });
            DropIndex("dbo.Issue", new[] { "CampusId" });
            DropIndex("dbo.Issue", new[] { "DepartmentId" });
            DropIndex("dbo.Issue", new[] { "EmployeeId" });
            DropIndex("dbo.Issue", new[] { "QueryId" });
            DropIndex("dbo.Issue", new[] { "IssueId" });
            DropIndex("dbo.Garbaged", new[] { "GarbagedBy" });
            DropIndex("dbo.Garbaged", new[] { "DeviceId" });
            DropIndex("dbo.Garbaged", new[] { "CpuId" });
            DropIndex("dbo.Garbaged", new[] { "QueryId" });
            DropIndex("dbo.Garbaged", new[] { "GarbagedId" });
            DropIndex("dbo.Supplier", new[] { "CategoryId" });
            DropIndex("dbo.Supplier", new[] { "QueryId" });
            DropIndex("dbo.Supplier", new[] { "SupplierId" });
            DropIndex("dbo.ItemDetails", new[] { "ItemId" });
            DropIndex("dbo.ItemDetails", new[] { "QueryId" });
            DropIndex("dbo.ItemDetails", new[] { "ItemDetailId" });
            DropIndex("dbo.Item", new[] { "SubCategoryId" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.Item", new[] { "QueryId" });
            DropIndex("dbo.Item", new[] { "ItemId" });
            DropIndex("dbo.CheckInDetails", new[] { "ItemCodeId" });
            DropIndex("dbo.CheckInDetails", new[] { "CheckInId" });
            DropIndex("dbo.CheckInDetails", new[] { "QueryId" });
            DropIndex("dbo.CheckInDetails", new[] { "CheckInDetailId" });
            DropIndex("dbo.CheckIn", new[] { "SupplierId" });
            DropIndex("dbo.CheckIn", new[] { "CategoryId" });
            DropIndex("dbo.CheckIn", new[] { "QueryId" });
            DropIndex("dbo.CheckIn", new[] { "CheckInId" });
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropIndex("dbo.SubCategory", new[] { "QueryId" });
            DropIndex("dbo.SubCategory", "IX_SubcategoryId");
            DropIndex("dbo.Category", new[] { "QueryId" });
            DropIndex("dbo.Category", new[] { "CategoryId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", "IX_Id");
            DropIndex("dbo.Employee", new[] { "QueryId" });
            DropIndex("dbo.Department", new[] { "SchoolId" });
            DropIndex("dbo.Department", new[] { "QueryId" });
            DropIndex("dbo.Department", new[] { "DepartmentId" });
            DropIndex("dbo.School", new[] { "Campus_CampusId" });
            DropIndex("dbo.School", new[] { "QueryId" });
            DropIndex("dbo.School", new[] { "SchoolId" });
            DropIndex("dbo.Campus", new[] { "QueryId" });
            DropIndex("dbo.Campus", new[] { "CampusId" });
            DropPrimaryKey("dbo.RequisitionDetails");
            DropPrimaryKey("dbo.Requisition");
            DropPrimaryKey("dbo.PurchaseBy");
            DropPrimaryKey("dbo.IssueDetail");
            DropPrimaryKey("dbo.Issue");
            DropPrimaryKey("dbo.Garbaged");
            DropPrimaryKey("dbo.Supplier");
            DropPrimaryKey("dbo.ItemDetails");
            DropPrimaryKey("dbo.Item");
            DropPrimaryKey("dbo.CheckInDetails");
            DropPrimaryKey("dbo.CheckIn");
            DropPrimaryKey("dbo.SubCategory");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.Department");
            DropPrimaryKey("dbo.School");
            DropPrimaryKey("dbo.Campus");
            AlterColumn("dbo.RequisitionDetails", "ItemCode", c => c.Guid(nullable: false));
            AlterColumn("dbo.RequisitionDetails", "RequisitionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Requisition", "CampusId", c => c.Guid());
            AlterColumn("dbo.Requisition", "EmployeeId", c => c.Guid());
            AlterColumn("dbo.IssueDetail", "IssueId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Issue", "CampusId", c => c.Guid());
            AlterColumn("dbo.Issue", "DepartmentId", c => c.Guid());
            AlterColumn("dbo.Issue", "EmployeeId", c => c.Guid());
            AlterColumn("dbo.Garbaged", "GarbagedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Garbaged", "DeviceId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Garbaged", "CpuId", c => c.Guid());
            AlterColumn("dbo.Supplier", "CategoryId", c => c.Guid());
            AlterColumn("dbo.ItemDetails", "ItemId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Item", "SubCategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Item", "CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CheckInDetails", "ItemCodeId", c => c.Guid());
            AlterColumn("dbo.CheckInDetails", "CheckInId", c => c.Guid());
            AlterColumn("dbo.CheckIn", "SupplierId", c => c.Guid());
            AlterColumn("dbo.CheckIn", "CategoryId", c => c.Guid());
            AlterColumn("dbo.SubCategory", "CategoryId", c => c.Guid());
            AlterColumn("dbo.Employee", "DepartmentId", c => c.Guid());
            AlterColumn("dbo.Employee", "EmployeeId", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Department", "SchoolId", c => c.Guid(nullable: false));
            AlterColumn("dbo.School", "Campus_CampusId", c => c.Guid());
            DropColumn("dbo.RequisitionDetails", "QueryId");
            DropColumn("dbo.RequisitionDetails", "RequisitionDetailId");
            DropColumn("dbo.Requisition", "QueryId");
            DropColumn("dbo.Requisition", "RequisitionId");
            DropColumn("dbo.PurchaseBy", "QueryId");
            DropColumn("dbo.PurchaseBy", "PurchaseById");
            DropColumn("dbo.IssueDetail", "QueryId");
            DropColumn("dbo.IssueDetail", "IssueDetailId");
            DropColumn("dbo.Issue", "QueryId");
            DropColumn("dbo.Issue", "IssueId");
            DropColumn("dbo.Garbaged", "QueryId");
            DropColumn("dbo.Garbaged", "GarbagedId");
            DropColumn("dbo.Supplier", "QueryId");
            DropColumn("dbo.Supplier", "SupplierId");
            DropColumn("dbo.ItemDetails", "QueryId");
            DropColumn("dbo.ItemDetails", "ItemDetailId");
            DropColumn("dbo.Item", "QueryId");
            DropColumn("dbo.Item", "ItemId");
            DropColumn("dbo.CheckInDetails", "QueryId");
            DropColumn("dbo.CheckInDetails", "CheckInDetailId");
            DropColumn("dbo.CheckIn", "QueryId");
            DropColumn("dbo.CheckIn", "CheckInId");
            DropColumn("dbo.SubCategory", "QueryId");
            DropColumn("dbo.SubCategory", "SubCategoryId");
            DropColumn("dbo.Category", "QueryId");
            DropColumn("dbo.Category", "CategoryId");
            DropColumn("dbo.Employee", "QueryId");
            DropColumn("dbo.Department", "QueryId");
            DropColumn("dbo.Department", "DepartmentId");
            DropColumn("dbo.School", "QueryId");
            DropColumn("dbo.School", "SchoolId");
            DropColumn("dbo.Campus", "QueryId");
            DropColumn("dbo.Campus", "CampusId");
            AddPrimaryKey("dbo.RequisitionDetails", "Id");
            AddPrimaryKey("dbo.Requisition", "Id");
            AddPrimaryKey("dbo.PurchaseBy", "Id");
            AddPrimaryKey("dbo.IssueDetail", "Id");
            AddPrimaryKey("dbo.Issue", "Id");
            AddPrimaryKey("dbo.Garbaged", "Id");
            AddPrimaryKey("dbo.Supplier", "Id");
            AddPrimaryKey("dbo.ItemDetails", "Id");
            AddPrimaryKey("dbo.Item", "Id");
            AddPrimaryKey("dbo.CheckInDetails", "Id");
            AddPrimaryKey("dbo.CheckIn", "Id");
            AddPrimaryKey("dbo.SubCategory", "Id");
            AddPrimaryKey("dbo.Category", "Id");
            AddPrimaryKey("dbo.Employee", "Id");
            AddPrimaryKey("dbo.Department", "Id");
            AddPrimaryKey("dbo.School", "Id");
            AddPrimaryKey("dbo.Campus", "Id");
            RenameColumn(table: "dbo.School", name: "Campus_CampusId", newName: "Campus_Id");
            CreateIndex("dbo.RequisitionDetails", "ItemCode");
            CreateIndex("dbo.RequisitionDetails", "RequisitionId");
            CreateIndex("dbo.RequisitionDetails", "Id", unique: true);
            CreateIndex("dbo.Requisition", "CampusID");
            CreateIndex("dbo.Requisition", "EmployeeId");
            CreateIndex("dbo.Requisition", "Id", unique: true);
            CreateIndex("dbo.PurchaseBy", "Id", unique: true);
            CreateIndex("dbo.IssueDetail", "IssueId");
            CreateIndex("dbo.IssueDetail", "Id", unique: true);
            CreateIndex("dbo.Issue", "CampusId");
            CreateIndex("dbo.Issue", "DepartmentId");
            CreateIndex("dbo.Issue", "EmployeeId");
            CreateIndex("dbo.Issue", "Id", unique: true);
            CreateIndex("dbo.Garbaged", "GarbagedBy");
            CreateIndex("dbo.Garbaged", "DeviceId");
            CreateIndex("dbo.Garbaged", "CpuId");
            CreateIndex("dbo.Garbaged", "Id", unique: true);
            CreateIndex("dbo.Supplier", "CategoryId");
            CreateIndex("dbo.Supplier", "Id", unique: true);
            CreateIndex("dbo.ItemDetails", "ItemId");
            CreateIndex("dbo.ItemDetails", "Id", unique: true);
            CreateIndex("dbo.Item", "SubCategoryId");
            CreateIndex("dbo.Item", "CategoryId");
            CreateIndex("dbo.Item", "Id", unique: true);
            CreateIndex("dbo.CheckInDetails", "ItemCodeId");
            CreateIndex("dbo.CheckInDetails", "CheckInId");
            CreateIndex("dbo.CheckInDetails", "Id", unique: true);
            CreateIndex("dbo.CheckIn", "SupplierId");
            CreateIndex("dbo.CheckIn", "CategoryId");
            CreateIndex("dbo.CheckIn", "Id", unique: true);
            CreateIndex("dbo.SubCategory", "CategoryId");
            CreateIndex("dbo.SubCategory", "Id", unique: true);
            CreateIndex("dbo.Category", "Id", unique: true);
            CreateIndex("dbo.Employee", "DepartmentId");
            CreateIndex("dbo.Employee", "Id", unique: true);
            CreateIndex("dbo.Department", "SchoolId");
            CreateIndex("dbo.Department", "Id", unique: true);
            CreateIndex("dbo.School", "Campus_Id");
            CreateIndex("dbo.School", "Id", unique: true);
            CreateIndex("dbo.Campus", "Id", unique: true);
            AddForeignKey("dbo.RequisitionDetails", "RequisitionId", "dbo.Requisition", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IssueDetail", "IssueId", "dbo.Issue", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier", "Id");
            AddForeignKey("dbo.RequisitionDetails", "ItemCode", "dbo.Item", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckInDetails", "ItemCodeId", "dbo.Item", "Id");
            AddForeignKey("dbo.ItemDetails", "ItemId", "dbo.Item", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Garbaged", "CpuId", "dbo.CheckInDetails", "Id");
            AddForeignKey("dbo.Garbaged", "DeviceId", "dbo.CheckInDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckInDetails", "CheckInId", "dbo.CheckIn", "Id");
            AddForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Supplier", "CategoryId", "dbo.Category", "Id");
            AddForeignKey("dbo.Item", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckIn", "CategoryId", "dbo.Category", "Id");
            AddForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category", "Id");
            AddForeignKey("dbo.Requisition", "EmployeeId", "dbo.Employee", "Id");
            AddForeignKey("dbo.Issue", "EmployeeId", "dbo.Employee", "Id");
            AddForeignKey("dbo.Garbaged", "GarbagedBy", "dbo.Employee", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issue", "DepartmentId", "dbo.Department", "Id");
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Department", "Id");
            AddForeignKey("dbo.Department", "SchoolId", "dbo.School", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisition", "CampusID", "dbo.Campus", "Id");
            AddForeignKey("dbo.Issue", "CampusId", "dbo.Campus", "Id");
            AddForeignKey("dbo.School", "Campus_Id", "dbo.Campus", "Id");
        }
    }
}
