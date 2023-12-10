namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.School",
                c => new
                    {
                        SchoolId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PriorityLevel = c.Int(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolId)
                .Index(t => t.SchoolId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.School", new[] { "Name" });
            DropIndex("dbo.School", new[] { "QueryId" });
            DropIndex("dbo.School", new[] { "SchoolId" });
            DropTable("dbo.School");
        }
    }
}
