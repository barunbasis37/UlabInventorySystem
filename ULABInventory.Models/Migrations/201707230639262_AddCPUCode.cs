namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCPUCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckInDetails", "CpuCode", c => c.String(nullable: false, maxLength: 250));
            CreateIndex("dbo.CheckInDetails", "CpuCode", name: "IX_CPUCode");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CheckInDetails", "IX_CPUCode");
            DropColumn("dbo.CheckInDetails", "CpuCode");
        }
    }
}
