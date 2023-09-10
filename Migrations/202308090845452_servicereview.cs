namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicereview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceReviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rate = c.Int(nullable: false),
                        title = c.String(nullable: false),
                        review = c.String(),
                        ServiceId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceReviews", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceReviews", "UserId", "dbo.Users");
            DropIndex("dbo.ServiceReviews", new[] { "UserId" });
            DropIndex("dbo.ServiceReviews", new[] { "ServiceId" });
            DropTable("dbo.ServiceReviews");
        }
    }
}
