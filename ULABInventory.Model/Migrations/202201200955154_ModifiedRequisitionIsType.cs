namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedRequisitionIsType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requisition", "IssueTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requisition", "IssueTypeId");
            AddForeignKey("dbo.Requisition", "IssueTypeId", "dbo.IssueType", "IssueTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisition", "IssueTypeId", "dbo.IssueType");
            DropIndex("dbo.Requisition", new[] { "IssueTypeId" });
            DropColumn("dbo.Requisition", "IssueTypeId");
        }
    }
}
