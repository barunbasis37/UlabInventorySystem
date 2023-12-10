namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedRequisitionD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequisitionDetail", "ItemCode", "dbo.Item");
            DropIndex("dbo.RequisitionDetail", new[] { "ItemCode" });
            AddColumn("dbo.RequisitionDetail", "CheckInDetailIdCode", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.RequisitionDetail", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.RequisitionDetail", "IsIssued", c => c.Boolean(nullable: false));
            AddColumn("dbo.RequisitionDetail", "ApproveRemarks", c => c.String(maxLength: 20));
            AddColumn("dbo.RequisitionDetail", "RequestRemarks", c => c.String(maxLength: 50));
            AddColumn("dbo.RequisitionDetail", "IsDenied", c => c.Boolean(nullable: false));
            AddColumn("dbo.RequisitionDetail", "DeniedBy", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.RequisitionDetail", "DeniedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequisitionDetail", "DeniedIP", c => c.String(nullable: false));
            CreateIndex("dbo.RequisitionDetail", "CheckInDetailIdCode");
            AddForeignKey("dbo.RequisitionDetail", "CheckInDetailIdCode", "dbo.CheckInDetail", "CheckInDetailId", cascadeDelete: true);
            DropColumn("dbo.RequisitionDetail", "ItemCode");
            DropColumn("dbo.RequisitionDetail", "Quantity");
            DropColumn("dbo.RequisitionDetail", "Remarks");
            DropColumn("dbo.RequisitionDetail", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequisitionDetail", "Status", c => c.String(maxLength: 10));
            AddColumn("dbo.RequisitionDetail", "Remarks", c => c.String(maxLength: 10));
            AddColumn("dbo.RequisitionDetail", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.RequisitionDetail", "ItemCode", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.RequisitionDetail", "CheckInDetailIdCode", "dbo.CheckInDetail");
            DropIndex("dbo.RequisitionDetail", new[] { "CheckInDetailIdCode" });
            DropColumn("dbo.RequisitionDetail", "DeniedIP");
            DropColumn("dbo.RequisitionDetail", "DeniedDateTime");
            DropColumn("dbo.RequisitionDetail", "DeniedBy");
            DropColumn("dbo.RequisitionDetail", "IsDenied");
            DropColumn("dbo.RequisitionDetail", "RequestRemarks");
            DropColumn("dbo.RequisitionDetail", "ApproveRemarks");
            DropColumn("dbo.RequisitionDetail", "IsIssued");
            DropColumn("dbo.RequisitionDetail", "IsApproved");
            DropColumn("dbo.RequisitionDetail", "CheckInDetailIdCode");
            CreateIndex("dbo.RequisitionDetail", "ItemCode");
            AddForeignKey("dbo.RequisitionDetail", "ItemCode", "dbo.Item", "ItemId", cascadeDelete: true);
        }
    }
}
