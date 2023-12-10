namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCPUAndDevicePKInCheckInDetails : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CheckInDetail");
            AddPrimaryKey("dbo.CheckInDetail", "CheckInDetailId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CheckInDetail");
            AddPrimaryKey("dbo.CheckInDetail", new[] { "CheckInDetailId", "CpuId", "DeviceId" });
        }
    }
}
