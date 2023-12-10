namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiyCheckInAddInvoiceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckIn", "InvoiceDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckIn", "InvoiceDate");
        }
    }
}
