namespace ULABInventory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentiUserTwoColumAdd23420171 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campus", "StartDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Campus", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campus", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Campus", "StartDateTime");
        }
    }
}
