namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.String(nullable: false, maxLength: 20),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 500),
                        Priority = c.Int(nullable: false),
                        CategoryId = c.String(maxLength: 10),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.CheckIn", "SupplierId", c => c.String(maxLength: 20));
            CreateIndex("dbo.CheckIn", "SupplierId");
            AddForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier", "SupplierId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckIn", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Supplier", "CategoryId", "dbo.Category");
            DropIndex("dbo.Supplier", new[] { "CategoryId" });
            DropIndex("dbo.Supplier", new[] { "QueryId" });
            DropIndex("dbo.Supplier", new[] { "SupplierId" });
            DropIndex("dbo.CheckIn", new[] { "SupplierId" });
            DropColumn("dbo.CheckIn", "SupplierId");
            DropTable("dbo.Supplier");
        }
    }
}
