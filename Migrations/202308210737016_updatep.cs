namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatep : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Places", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Places", new[] { "CategoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Places", "CategoryId");
            AddForeignKey("dbo.Places", "CategoryId", "dbo.Categories", "id");
        }
    }
}
