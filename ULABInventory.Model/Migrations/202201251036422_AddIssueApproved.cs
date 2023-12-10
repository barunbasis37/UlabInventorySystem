namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssueApproved : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueApproved",
                c => new
                    {
                        IssueApprovedId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        RequisitionDId = c.String(nullable: false, maxLength: 20),
                        CurrentStatus = c.String(maxLength: 150),
                        ReturnRemarks = c.String(maxLength: 150),
                        ReturnBy = c.String(nullable: false, maxLength: 10),
                        ReturnIp = c.String(nullable: false, maxLength: 20),
                        ReturnDate = c.DateTime(nullable: false),
                        GarbageDescription = c.String(maxLength: 150),
                        GarbageBy = c.String(nullable: false, maxLength: 10),
                        GarbageIp = c.String(nullable: false, maxLength: 20),
                        GarbageDate = c.DateTime(nullable: false),
                        WarrantyReason = c.String(maxLength: 150),
                        WarrantyBy = c.String(nullable: false, maxLength: 10),
                        WarrantyIp = c.String(nullable: false, maxLength: 20),
                        WarrantyDate = c.DateTime(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IssueApprovedId)
                .ForeignKey("dbo.RequisitionDetail", t => t.RequisitionDId, cascadeDelete: true)
                .Index(t => t.IssueApprovedId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.RequisitionDId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueApproved", "RequisitionDId", "dbo.RequisitionDetail");
            DropIndex("dbo.IssueApproved", new[] { "RequisitionDId" });
            DropIndex("dbo.IssueApproved", new[] { "QueryId" });
            DropIndex("dbo.IssueApproved", new[] { "IssueApprovedId" });
            DropTable("dbo.IssueApproved");
        }
    }
}
