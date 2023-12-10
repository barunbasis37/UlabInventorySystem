namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCatMAndSubCatM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategoryM", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.SubCategoryM", "CategoryM_CategoryId", "dbo.CategoryM");
            DropIndex("dbo.CategoryM", new[] { "QueryId" });
            DropIndex("dbo.SubCategoryM", new[] { "QueryId" });
            DropIndex("dbo.SubCategoryM", new[] { "CategoryId" });
            DropIndex("dbo.SubCategoryM", new[] { "CategoryM_CategoryId" });
            DropTable("dbo.CategoryM");
            DropTable("dbo.SubCategoryM");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategoryM",
                c => new
                    {
                        SubCategoryId = c.String(nullable: false, maxLength: 128),
                        QueryId = c.Guid(nullable: false, identity: true),
                        SubCategoryCustomID = c.String(nullable: false, maxLength: 10),
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
                        CategoryM_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.CategoryM",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        QueryId = c.Guid(nullable: false, identity: true),
                        CategoryCustomID = c.String(nullable: false, maxLength: 10),
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
                .PrimaryKey(t => t.CategoryId);
            
            CreateIndex("dbo.SubCategoryM", "CategoryM_CategoryId");
            CreateIndex("dbo.SubCategoryM", "CategoryId");
            CreateIndex("dbo.SubCategoryM", "QueryId", unique: true);
            CreateIndex("dbo.CategoryM", "QueryId", unique: true);
            AddForeignKey("dbo.SubCategoryM", "CategoryM_CategoryId", "dbo.CategoryM", "CategoryId");
            AddForeignKey("dbo.SubCategoryM", "CategoryId", "dbo.Category", "CategoryId");
        }
    }
}
