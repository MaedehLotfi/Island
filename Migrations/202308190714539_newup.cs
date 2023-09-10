namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "CategoryId", c => c.Int());
            AddColumn("dbo.Services", "CategoryId", c => c.Int());
            CreateIndex("dbo.Places", "CategoryId");
            CreateIndex("dbo.Services", "CategoryId");
            AddForeignKey("dbo.Places", "CategoryId", "dbo.Categories", "id");
            AddForeignKey("dbo.Services", "CategoryId", "dbo.Categories", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Places", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Services", new[] { "CategoryId" });
            DropIndex("dbo.Places", new[] { "CategoryId" });
            DropColumn("dbo.Services", "CategoryId");
            DropColumn("dbo.Places", "CategoryId");
        }
    }
}
