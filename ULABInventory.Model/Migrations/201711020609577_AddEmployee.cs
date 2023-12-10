namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        QueryId = c.Guid(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 150),
                        Designation = c.String(nullable: false),
                        DepartmentId = c.String(maxLength: 10),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.EmployeeId, unique: true, name: "IX_Id")
                .Index(t => t.Name, unique: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "Name" });
            DropIndex("dbo.Employee", "IX_Id");
            DropIndex("dbo.Employee", new[] { "QueryId" });
            DropTable("dbo.Employee");
        }
    }
}
