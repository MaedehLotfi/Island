namespace Island.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceGalleries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        filePath = c.String(),
                        PlaceId = c.Int(nullable: false),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        latG = c.String(nullable: false),
                        longG = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        TellNumber = c.String(),
                        OpennigHour = c.String(),
                        MoreInfo = c.String(),
                        Instagram = c.String(),
                        Website = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ServiceGalleries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        filePath = c.String(),
                        ServiceId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        TellNumber = c.String(),
                        Gender = c.String(),
                        Bio = c.String(),
                        Website = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PlaceGalleries", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Places", "UserId", "dbo.Users");
            DropForeignKey("dbo.ServiceGalleries", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "UserId", "dbo.Users");
            DropForeignKey("dbo.ServiceGalleries", "UserId", "dbo.Users");
            DropForeignKey("dbo.PlaceGalleries", "User_id", "dbo.Users");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Services", new[] { "UserId" });
            DropIndex("dbo.ServiceGalleries", new[] { "UserId" });
            DropIndex("dbo.ServiceGalleries", new[] { "ServiceId" });
            DropIndex("dbo.Places", new[] { "UserId" });
            DropIndex("dbo.PlaceGalleries", new[] { "User_id" });
            DropIndex("dbo.PlaceGalleries", new[] { "PlaceId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceGalleries");
            DropTable("dbo.Users");
            DropTable("dbo.Places");
            DropTable("dbo.PlaceGalleries");
        }
    }
}
