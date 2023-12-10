namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsApproved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issue", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issue", "IsApproved");
        }
    }
}
