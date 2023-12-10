namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedIssueAddCheckInDetailsId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IssueDetail", name: "DeviceId", newName: "CheckInDetailId");
            RenameIndex(table: "dbo.IssueDetail", name: "IX_DeviceId", newName: "IX_CheckInDetailId");
            DropColumn("dbo.IssueDetail", "CpuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssueDetail", "CpuId", c => c.String(maxLength: 150));
            RenameIndex(table: "dbo.IssueDetail", name: "IX_CheckInDetailId", newName: "IX_DeviceId");
            RenameColumn(table: "dbo.IssueDetail", name: "CheckInDetailId", newName: "DeviceId");
        }
    }
}
