namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sreprt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceReports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        message = c.String(),
                        ServiceReviewId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.ServiceReviews", t => t.ServiceReviewId, cascadeDelete: true)
                .Index(t => t.ServiceReviewId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceReports", "ServiceReviewId", "dbo.ServiceReviews");
            DropForeignKey("dbo.ServiceReports", "UserId", "dbo.Users");
            DropIndex("dbo.ServiceReports", new[] { "UserId" });
            DropIndex("dbo.ServiceReports", new[] { "ServiceReviewId" });
            DropTable("dbo.ServiceReports");
        }
    }
}
