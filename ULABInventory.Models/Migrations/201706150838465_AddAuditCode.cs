namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckInDetails", "AuditCode", c => c.String(maxLength: 250));
            CreateIndex("dbo.CheckInDetails", "AuditCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CheckInDetails", new[] { "AuditCode" });
            DropColumn("dbo.CheckInDetails", "AuditCode");
        }
    }
}
