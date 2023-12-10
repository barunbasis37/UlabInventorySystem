namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQRPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckInDetail", "QRCodeImgPath", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckInDetail", "QRCodeImgPath");
        }
    }
}
