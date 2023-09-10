namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceReviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rate = c.Int(nullable: false),
                        title = c.String(nullable: false),
                        review = c.String(),
                        PlaceId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaceReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.PlaceReviews", "PlaceId", "dbo.Places");
            DropIndex("dbo.PlaceReviews", new[] { "UserId" });
            DropIndex("dbo.PlaceReviews", new[] { "PlaceId" });
            DropTable("dbo.PlaceReviews");
        }
    }
}
