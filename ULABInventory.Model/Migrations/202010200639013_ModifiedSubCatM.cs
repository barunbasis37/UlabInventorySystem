namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSubCatM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategory", "CategoryM_CategoryId", "dbo.CategoryM");
            DropIndex("dbo.SubCategory", new[] { "CategoryM_CategoryId" });
            AddColumn("dbo.SubCategoryM", "SubCategoryCustomID", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.SubCategoryM", "CategoryM_CategoryId", c => c.Int());
            CreateIndex("dbo.SubCategoryM", "CategoryM_CategoryId");
            AddForeignKey("dbo.SubCategoryM", "CategoryM_CategoryId", "dbo.CategoryM", "CategoryId");
            DropColumn("dbo.SubCategory", "CategoryM_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCategory", "CategoryM_CategoryId", c => c.Int());
            DropForeignKey("dbo.SubCategoryM", "CategoryM_CategoryId", "dbo.CategoryM");
            DropIndex("dbo.SubCategoryM", new[] { "CategoryM_CategoryId" });
            DropColumn("dbo.SubCategoryM", "CategoryM_CategoryId");
            DropColumn("dbo.SubCategoryM", "SubCategoryCustomID");
            CreateIndex("dbo.SubCategory", "CategoryM_CategoryId");
            AddForeignKey("dbo.SubCategory", "CategoryM_CategoryId", "dbo.CategoryM", "CategoryId");
        }
    }
}
