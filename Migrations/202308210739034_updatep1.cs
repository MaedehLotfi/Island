namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatep1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Places", "CategoryId");
            AddForeignKey("dbo.Places", "CategoryId", "dbo.Categories", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Places", new[] { "CategoryId" });
        }
    }
}
