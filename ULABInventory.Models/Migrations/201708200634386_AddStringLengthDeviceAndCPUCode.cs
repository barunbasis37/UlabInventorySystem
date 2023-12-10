namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLengthDeviceAndCPUCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IssueDetail", "CpuId", c => c.String(maxLength: 150));
            AlterColumn("dbo.IssueDetail", "DeviceId", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IssueDetail", "DeviceId", c => c.String());
            AlterColumn("dbo.IssueDetail", "CpuId", c => c.String());
        }
    }
}
