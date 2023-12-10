namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCPUAndDevicePKInCheckInDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckInDetail", "CheckInId", "dbo.CheckIn");
            DropIndex("dbo.CheckInDetail", "IX_CPUCode");
            DropIndex("dbo.CheckInDetail", new[] { "DeviceCode" });
            DropIndex("dbo.CheckInDetail", new[] { "CheckInId" });
            DropPrimaryKey("dbo.CheckInDetail");
            AddColumn("dbo.CheckInDetail", "CpuId", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.CheckInDetail", "DeviceId", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.CheckInDetail", "CheckInId", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.CheckInDetail", new[] { "CheckInDetailId", "CpuId", "DeviceId" });
            CreateIndex("dbo.CheckInDetail", "CpuId", name: "IX_CPUCode");
            CreateIndex("dbo.CheckInDetail", "DeviceId", unique: true, name: "IX_DeviceCode");
            CreateIndex("dbo.CheckInDetail", "CheckInId");
            AddForeignKey("dbo.CheckInDetail", "CheckInId", "dbo.CheckIn", "CheckInId", cascadeDelete: true);
            DropColumn("dbo.CheckInDetail", "CpuCode");
            DropColumn("dbo.CheckInDetail", "DeviceCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckInDetail", "DeviceCode", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.CheckInDetail", "CpuCode", c => c.String(nullable: false, maxLength: 250));
            DropForeignKey("dbo.CheckInDetail", "CheckInId", "dbo.CheckIn");
            DropIndex("dbo.CheckInDetail", new[] { "CheckInId" });
            DropIndex("dbo.CheckInDetail", "IX_DeviceCode");
            DropIndex("dbo.CheckInDetail", "IX_CPUCode");
            DropPrimaryKey("dbo.CheckInDetail");
            AlterColumn("dbo.CheckInDetail", "CheckInId", c => c.String(maxLength: 20));
            DropColumn("dbo.CheckInDetail", "DeviceId");
            DropColumn("dbo.CheckInDetail", "CpuId");
            AddPrimaryKey("dbo.CheckInDetail", "CheckInDetailId");
            CreateIndex("dbo.CheckInDetail", "CheckInId");
            CreateIndex("dbo.CheckInDetail", "DeviceCode", unique: true);
            CreateIndex("dbo.CheckInDetail", "CpuCode", name: "IX_CPUCode");
            AddForeignKey("dbo.CheckInDetail", "CheckInId", "dbo.CheckIn", "CheckInId");
        }
    }
}
