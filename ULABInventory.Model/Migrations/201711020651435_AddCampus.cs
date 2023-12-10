namespace ULABInventory.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusId = c.String(nullable: false, maxLength: 10),
                        QueryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 20),
                        StartDateTime = c.DateTime(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 50),
                        PostedIp = c.String(nullable: false, maxLength: 50),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedIp = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CampusId)
                .Index(t => t.CampusId)
                .Index(t => t.QueryId, unique: true)
                .Index(t => t.Name, unique: true);
            
            AddColumn("dbo.School", "Campus_CampusId", c => c.String(maxLength: 10));
            CreateIndex("dbo.School", "Campus_CampusId");
            AddForeignKey("dbo.School", "Campus_CampusId", "dbo.Campus", "CampusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.School", "Campus_CampusId", "dbo.Campus");
            DropIndex("dbo.School", new[] { "Campus_CampusId" });
            DropIndex("dbo.Campus", new[] { "Name" });
            DropIndex("dbo.Campus", new[] { "QueryId" });
            DropIndex("dbo.Campus", new[] { "CampusId" });
            DropColumn("dbo.School", "Campus_CampusId");
            DropTable("dbo.Campus");
        }
    }
}
