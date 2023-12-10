namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssueType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueType",
                c => new
                    {
                        QueryId = c.Guid(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Priority = c.Int(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.QueryId, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.IssueType", new[] { "QueryId" });
            DropTable("dbo.IssueType");
        }
    }
}
