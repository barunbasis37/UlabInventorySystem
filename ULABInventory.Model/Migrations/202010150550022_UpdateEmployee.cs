namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployee : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employee", name: "DepartmentId", newName: "Department_DepartmentId");
            RenameIndex(table: "dbo.Employee", name: "IX_DepartmentId", newName: "IX_Department_DepartmentId");
            AddColumn("dbo.Employee", "ProgramId", c => c.String(maxLength: 10));
            CreateIndex("dbo.Employee", "ProgramId");
            AddForeignKey("dbo.Employee", "ProgramId", "dbo.Program", "ProgramId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "ProgramId", "dbo.Program");
            DropIndex("dbo.Employee", new[] { "ProgramId" });
            DropColumn("dbo.Employee", "ProgramId");
            RenameIndex(table: "dbo.Employee", name: "IX_Department_DepartmentId", newName: "IX_DepartmentId");
            RenameColumn(table: "dbo.Employee", name: "Department_DepartmentId", newName: "DepartmentId");
        }
    }
}
