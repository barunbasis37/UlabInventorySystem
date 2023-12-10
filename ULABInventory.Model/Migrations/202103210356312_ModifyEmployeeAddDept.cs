namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEmployeeAddDept : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employee", name: "Department_DepartmentId", newName: "DepartmentId");
            RenameIndex(table: "dbo.Employee", name: "IX_Department_DepartmentId", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employee", name: "IX_DepartmentId", newName: "IX_Department_DepartmentId");
            RenameColumn(table: "dbo.Employee", name: "DepartmentId", newName: "Department_DepartmentId");
        }
    }
}
