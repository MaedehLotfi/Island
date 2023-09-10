namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepg : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PlaceGalleries", name: "User_id", newName: "UserId");
            RenameIndex(table: "dbo.PlaceGalleries", name: "IX_User_id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PlaceGalleries", name: "IX_UserId", newName: "IX_User_id");
            RenameColumn(table: "dbo.PlaceGalleries", name: "UserId", newName: "User_id");
        }
    }
}
