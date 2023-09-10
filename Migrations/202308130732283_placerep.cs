namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class placerep : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PlaceReports", name: "PlaceReportId", newName: "PlaceReviewId");
            RenameIndex(table: "dbo.PlaceReports", name: "IX_PlaceReportId", newName: "IX_PlaceReviewId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PlaceReports", name: "IX_PlaceReviewId", newName: "IX_PlaceReportId");
            RenameColumn(table: "dbo.PlaceReports", name: "PlaceReviewId", newName: "PlaceReportId");
        }
    }
}
