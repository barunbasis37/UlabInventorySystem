namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyIssue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issue", "IssueTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issue", "IssueTypeId");
        }
    }
}
