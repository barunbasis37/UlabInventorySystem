namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyIssueType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.IssueType", "IX_IssueTypeId");
            DropPrimaryKey("dbo.IssueType");
            AddColumn("dbo.IssueType", "IssueTypeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IssueType", "IssueTypeID");
            DropColumn("dbo.IssueType", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssueType", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.IssueType");
            DropColumn("dbo.IssueType", "IssueTypeID");
            AddPrimaryKey("dbo.IssueType", "ID");
            CreateIndex("dbo.IssueType", "ID", name: "IX_IssueTypeId");
        }
    }
}
