namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedIssueAddFKIssTypeId : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Issue", "IssueTypeId");
            AddForeignKey("dbo.Issue", "IssueTypeId", "dbo.IssueType", "IssueTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issue", "IssueTypeId", "dbo.IssueType");
            DropIndex("dbo.Issue", new[] { "IssueTypeId" });
        }
    }
}
