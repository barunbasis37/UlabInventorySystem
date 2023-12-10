namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCheckInDItemDetails : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CheckInDetail", name: "ItemCodeId", newName: "ItemId");
            RenameIndex(table: "dbo.CheckInDetail", name: "IX_ItemCodeId", newName: "IX_ItemId");
            AddColumn("dbo.CheckInDetail", "ItemDetailsId", c => c.String(maxLength: 20));
            CreateIndex("dbo.CheckInDetail", "ItemDetailsId");
            AddForeignKey("dbo.CheckInDetail", "ItemDetailsId", "dbo.ItemDetail", "ItemDetailId");
            DropColumn("dbo.CheckInDetail", "ItemModel");
            DropColumn("dbo.CheckInDetail", "ItemSize");
            DropColumn("dbo.CheckInDetail", "ItemBrand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckInDetail", "ItemBrand", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CheckInDetail", "ItemSize", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CheckInDetail", "ItemModel", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.CheckInDetail", "ItemDetailsId", "dbo.ItemDetail");
            DropIndex("dbo.CheckInDetail", new[] { "ItemDetailsId" });
            DropColumn("dbo.CheckInDetail", "ItemDetailsId");
            RenameIndex(table: "dbo.CheckInDetail", name: "IX_ItemId", newName: "IX_ItemCodeId");
            RenameColumn(table: "dbo.CheckInDetail", name: "ItemId", newName: "ItemCodeId");
        }
    }
}
