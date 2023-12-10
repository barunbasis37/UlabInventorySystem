namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDevCpuDatatype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IssueDetail", "DeviceId", "dbo.CheckInDetails");
            DropForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails");
            DropIndex("dbo.IssueDetail", new[] { "CpuId" });
            DropIndex("dbo.IssueDetail", new[] { "DeviceId" });
            AlterColumn("dbo.IssueDetail", "CpuId", c => c.String());
            AlterColumn("dbo.IssueDetail", "DeviceId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IssueDetail", "DeviceId", c => c.Guid());
            AlterColumn("dbo.IssueDetail", "CpuId", c => c.Guid());
            CreateIndex("dbo.IssueDetail", "DeviceId");
            CreateIndex("dbo.IssueDetail", "CpuId");
            AddForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails", "Id");
            AddForeignKey("dbo.IssueDetail", "DeviceId", "dbo.CheckInDetails", "Id");
        }
    }
}
