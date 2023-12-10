namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifiedSubCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubCategoryM",
                c => new
                    {
                        SubCategoryId = c.String(nullable: false, maxLength: 128),
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
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategoryM", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubCategoryM", new[] { "CategoryId" });
            DropIndex("dbo.SubCategoryM", new[] { "QueryId" });
            DropTable("dbo.SubCategoryM");
        }
    }
}
