namespace UlabInventory.Web.MVC.Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameDepartmentUser2442017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Department");
            DropColumn("dbo.AspNetUsers", "EmployeeName");
        }
    }
}
