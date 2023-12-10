namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryAndSubCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.String(nullable: false, maxLength: 10),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Priority = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.QueryId, unique: true);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        SubCategoryId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Priority = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.String(maxLength: 10),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.SubCategoryId, name: "IX_SubcategoryId")
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropIndex("dbo.SubCategory", new[] { "QueryId" });
            DropIndex("dbo.SubCategory", "IX_SubcategoryId");
            DropIndex("dbo.Category", new[] { "QueryId" });
            DropIndex("dbo.Category", new[] { "CategoryId" });
            DropTable("dbo.SubCategory");
            DropTable("dbo.Category");
        }
    }
}
