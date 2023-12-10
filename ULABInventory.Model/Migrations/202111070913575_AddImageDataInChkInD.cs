namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageDataInChkInD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckInDetail", "QRImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckInDetail", "QRImage");
        }
    }
}
