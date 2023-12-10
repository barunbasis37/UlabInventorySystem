namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCPUIdDevIdDatatypeChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueDetail", "CpuId", c => c.Guid());
            CreateIndex("dbo.IssueDetail", "CpuId");
            AddForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueDetail", "CpuId", "dbo.CheckInDetails");
            DropIndex("dbo.IssueDetail", new[] { "CpuId" });
            DropColumn("dbo.IssueDetail", "CpuId");
        }
    }
}
