namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModiifedSubCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubCategory", "SubCatDescription", c => c.String(maxLength: 100));
            DropColumn("dbo.SubCategory", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCategory", "Description", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.SubCategory", "SubCatDescription");
        }
    }
}
