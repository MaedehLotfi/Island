namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlaceId = c.Int(),
                        ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Places", t => t.PlaceId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "PlaceId", "dbo.Places");
            DropIndex("dbo.Favorites", new[] { "ServiceId" });
            DropIndex("dbo.Favorites", new[] { "PlaceId" });
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropTable("dbo.Favorites");
        }
    }
}
