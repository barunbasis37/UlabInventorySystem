namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryM",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
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
                .Index(t => t.QueryId, unique: true);
            
            AddColumn("dbo.SubCategory", "CategoryM_CategoryId", c => c.Int());
            CreateIndex("dbo.SubCategory", "CategoryM_CategoryId");
            AddForeignKey("dbo.SubCategory", "CategoryM_CategoryId", "dbo.CategoryM", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategory", "CategoryM_CategoryId", "dbo.CategoryM");
            DropIndex("dbo.CategoryM", new[] { "QueryId" });
            DropIndex("dbo.SubCategory", new[] { "CategoryM_CategoryId" });
            DropColumn("dbo.SubCategory", "CategoryM_CategoryId");
            DropTable("dbo.CategoryM");
        }
    }
}
