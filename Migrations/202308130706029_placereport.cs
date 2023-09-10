namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class placereport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceReports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        message = c.String(),
                        PlaceReportId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.PlaceReports", t => t.PlaceReportId)
                .Index(t => t.PlaceReportId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaceReports", "PlaceReportId", "dbo.PlaceReports");
            DropForeignKey("dbo.PlaceReports", "UserId", "dbo.Users");
            DropIndex("dbo.PlaceReports", new[] { "UserId" });
            DropIndex("dbo.PlaceReports", new[] { "PlaceReportId" });
            DropTable("dbo.PlaceReports");
        }
    }
}
