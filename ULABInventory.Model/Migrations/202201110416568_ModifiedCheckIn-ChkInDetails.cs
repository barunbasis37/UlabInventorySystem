namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCheckInChkInDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckIn", "PurchaseRequestNo", c => c.String(maxLength: 100));
            AddColumn("dbo.CheckIn", "WorkOrderNo", c => c.String(maxLength: 100));
            AddColumn("dbo.CheckInDetail", "WarrentyDuration", c => c.Int(nullable: false));
            DropColumn("dbo.CheckIn", "ReceiptNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIn", "ReceiptNo", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.CheckInDetail", "WarrentyDuration");
            DropColumn("dbo.CheckIn", "WorkOrderNo");
            DropColumn("dbo.CheckIn", "PurchaseRequestNo");
        }
    }
}
