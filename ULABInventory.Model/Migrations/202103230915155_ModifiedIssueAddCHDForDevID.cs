namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedIssueAddCHDForDevID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IssueDetail", "DeviceId", c => c.String(maxLength: 20));
            CreateIndex("dbo.IssueDetail", "DeviceId");
            AddForeignKey("dbo.IssueDetail", "DeviceId", "dbo.CheckInDetail", "CheckInDetailId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueDetail", "DeviceId", "dbo.CheckInDetail");
            DropIndex("dbo.IssueDetail", new[] { "DeviceId" });
            AlterColumn("dbo.IssueDetail", "DeviceId", c => c.String(maxLength: 150));
        }
    }
}
