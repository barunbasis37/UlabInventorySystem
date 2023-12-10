namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyIssueAndIssueType : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.IssueType");
            AlterColumn("dbo.IssueType", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.IssueType", "Name", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.IssueType", "ID");
            CreateIndex("dbo.IssueType", "ID", name: "IX_IssueTypeId");
            CreateIndex("dbo.IssueType", "Name", unique: true, name: "IX_ReturnRemark");
        }
        
        public override void Down()
        {
            DropIndex("dbo.IssueType", "IX_ReturnRemark");
            DropIndex("dbo.IssueType", "IX_IssueTypeId");
            DropPrimaryKey("dbo.IssueType");
            AlterColumn("dbo.IssueType", "Name", c => c.String());
            AlterColumn("dbo.IssueType", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IssueType", "ID");
        }
    }
}
