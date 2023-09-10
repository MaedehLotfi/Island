namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class placereports : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaceReports", "PlaceReportId", "dbo.PlaceReports");
            AddForeignKey("dbo.PlaceReports", "PlaceReportId", "dbo.PlaceReviews", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaceReports", "PlaceReportId", "dbo.PlaceReviews");
            AddForeignKey("dbo.PlaceReports", "PlaceReportId", "dbo.PlaceReports", "id");
        }
    }
}
