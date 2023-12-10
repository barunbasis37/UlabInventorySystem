namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDeviceCode : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CheckInDetails", new[] { "DeviceCode" });
            AlterColumn("dbo.CheckInDetails", "DeviceCode", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckInDetails", "DeviceCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CheckInDetails", new[] { "DeviceCode" });
            AlterColumn("dbo.CheckInDetails", "DeviceCode", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckInDetails", "DeviceCode", unique: true);
        }
    }
}
