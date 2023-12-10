namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemAndItemDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Priority = c.Int(nullable: false),
                        CategoryId = c.String(nullable: false, maxLength: 10),
                        SubCategoryId = c.String(nullable: false, maxLength: 20),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.ItemDetail",
                c => new
                    {
                        ItemDetailId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        ItemId = c.String(nullable: false, maxLength: 20),
                        Model = c.String(nullable: false, maxLength: 50),
                        Size = c.String(nullable: false, maxLength: 50),
                        Brand = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Details = c.String(maxLength: 500),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemDetailId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemDetailId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.ItemId)
                .Index(t => t.Model)
                .Index(t => t.Size)
                .Index(t => t.Brand);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.ItemDetail", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropIndex("dbo.ItemDetail", new[] { "Brand" });
            DropIndex("dbo.ItemDetail", new[] { "Size" });
            DropIndex("dbo.ItemDetail", new[] { "Model" });
            DropIndex("dbo.ItemDetail", new[] { "ItemId" });
            DropIndex("dbo.ItemDetail", new[] { "QueryId" });
            DropIndex("dbo.ItemDetail", new[] { "ItemDetailId" });
            DropIndex("dbo.Item", new[] { "SubCategoryId" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.Item", new[] { "Name" });
            DropIndex("dbo.Item", new[] { "QueryId" });
            DropIndex("dbo.Item", new[] { "ItemId" });
            DropTable("dbo.ItemDetail");
            DropTable("dbo.Item");
        }
    }
}
