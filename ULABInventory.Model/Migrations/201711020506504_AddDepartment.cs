namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.String(nullable: false, maxLength: 10),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SchoolId = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        Description = c.String(maxLength: 100),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.School", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.Name)
                .Index(t => t.SchoolId)
                .Index(t => t.Type);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Department", "SchoolId", "dbo.School");
            DropIndex("dbo.Department", new[] { "Type" });
            DropIndex("dbo.Department", new[] { "SchoolId" });
            DropIndex("dbo.Department", new[] { "Name" });
            DropIndex("dbo.Department", new[] { "QueryId" });
            DropIndex("dbo.Department", new[] { "DepartmentId" });
            DropTable("dbo.Department");
        }
    }
}
