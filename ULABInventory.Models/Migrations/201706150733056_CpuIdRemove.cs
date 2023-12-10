namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CpuIdRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails");
            DropIndex("dbo.CheckInDetails", "IX_CPUCode");
            DropIndex("dbo.IssueDetail", new[] { "CpuId" });
            DropColumn("dbo.CheckInDetails", "CpuCode");
            DropColumn("dbo.IssueDetail", "CpuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssueDetail", "CpuId", c => c.Guid());
            AddColumn("dbo.CheckInDetails", "CpuCode", c => c.Int(nullable: false));
            CreateIndex("dbo.IssueDetail", "CpuId");
            CreateIndex("dbo.CheckInDetails", "CpuCode", unique: true, name: "IX_CPUCode");
            AddForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails", "Id");
        }
    }
}
