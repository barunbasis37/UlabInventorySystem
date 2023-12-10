namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgram : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Program",
                c => new
                    {
                        ProgramId = c.String(nullable: false, maxLength: 10),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        DepartmentId = c.String(nullable: false, maxLength: 10),
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
                .PrimaryKey(t => t.ProgramId)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.Name, name: "IX_ProgramName")
                .Index(t => t.DepartmentId)
                .Index(t => t.Type);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Program", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Program", new[] { "Type" });
            DropIndex("dbo.Program", new[] { "DepartmentId" });
            DropIndex("dbo.Program", "IX_ProgramName");
            DropIndex("dbo.Program", new[] { "QueryId" });
            DropIndex("dbo.Program", new[] { "ProgramId" });
            DropTable("dbo.Program");
        }
    }
}
