namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedChekDAddRequiredItmD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckInDetail", "ItemDetailsId", "dbo.ItemDetail");
            DropIndex("dbo.CheckInDetail", new[] { "ItemDetailsId" });
            AlterColumn("dbo.CheckInDetail", "ItemDetailsId", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.CheckInDetail", "ItemDetailsId");
            AddForeignKey("dbo.CheckInDetail", "ItemDetailsId", "dbo.ItemDetail", "ItemDetailId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInDetail", "ItemDetailsId", "dbo.ItemDetail");
            DropIndex("dbo.CheckInDetail", new[] { "ItemDetailsId" });
            AlterColumn("dbo.CheckInDetail", "ItemDetailsId", c => c.String(maxLength: 20));
            CreateIndex("dbo.CheckInDetail", "ItemDetailsId");
            AddForeignKey("dbo.CheckInDetail", "ItemDetailsId", "dbo.ItemDetail", "ItemDetailId");
        }
    }
}
