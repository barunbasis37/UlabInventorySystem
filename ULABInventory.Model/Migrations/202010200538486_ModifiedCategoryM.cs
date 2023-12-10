namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCategoryM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryM", "CategoryCustomID", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategoryM", "CategoryCustomID");
        }
    }
}
