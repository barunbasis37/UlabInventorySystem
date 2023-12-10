namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssueAndIssueDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issue",
                c => new
                    {
                        IssueId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        EmployeeId = c.String(maxLength: 20),
                        DepartmentId = c.String(maxLength: 10),
                        CampusId = c.String(maxLength: 10),
                        Floor = c.String(nullable: false),
                        Room = c.String(nullable: false),
                        IssueRemark = c.String(maxLength: 100),
                        ReturnRemark = c.String(maxLength: 100),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedId = c.String(nullable: false, maxLength: 30),
                        ApprovedDateTime = c.DateTime(nullable: false),
                        ApprovedIp = c.String(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IssueId)
                .ForeignKey("dbo.Campus", t => t.CampusId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.IssueId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CampusId)
                .Index(t => t.IssueRemark, unique: true)
                .Index(t => t.ReturnRemark, unique: true)
                .Index(t => t.ApprovedId, name: "IX_Id");
            
            CreateTable(
                "dbo.IssueDetail",
                c => new
                    {
                        IssueDetailId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        IssueId = c.String(nullable: false, maxLength: 20),
                        CpuId = c.String(maxLength: 150),
                        DeviceId = c.String(maxLength: 150),
                        AgainstDeviceCode = c.String(maxLength: 50),
                        CurrentStatus = c.String(maxLength: 150),
                        DeviceReturnRemarks = c.String(maxLength: 150),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        ReturnComment = c.String(maxLength: 150),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IssueDetailId)
                .ForeignKey("dbo.Issue", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.IssueDetailId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.IssueId)
                .Index(t => t.AgainstDeviceCode, name: "IX_Id");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueDetail", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.Issue", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Issue", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Issue", "CampusId", "dbo.Campus");
            DropIndex("dbo.IssueDetail", "IX_Id");
            DropIndex("dbo.IssueDetail", new[] { "IssueId" });
            DropIndex("dbo.IssueDetail", new[] { "QueryId" });
            DropIndex("dbo.IssueDetail", new[] { "IssueDetailId" });
            DropIndex("dbo.Issue", "IX_Id");
            DropIndex("dbo.Issue", new[] { "ReturnRemark" });
            DropIndex("dbo.Issue", new[] { "IssueRemark" });
            DropIndex("dbo.Issue", new[] { "CampusId" });
            DropIndex("dbo.Issue", new[] { "DepartmentId" });
            DropIndex("dbo.Issue", new[] { "EmployeeId" });
            DropIndex("dbo.Issue", new[] { "QueryId" });
            DropIndex("dbo.Issue", new[] { "IssueId" });
            DropTable("dbo.IssueDetail");
            DropTable("dbo.Issue");
        }
    }
}
