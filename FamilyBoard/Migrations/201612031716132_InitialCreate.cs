namespace FamilyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhotoComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateCreated = c.String(),
                        PhotoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.PhotoId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateCreated = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateCreated = c.String(),
                        VideoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .Index(t => t.VideoId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.PhotoComments", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.VideoComments", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.VideoComments", "UserId", "dbo.Users");
            DropIndex("dbo.VideoComments", new[] { "UserId" });
            DropIndex("dbo.VideoComments", new[] { "VideoId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.PhotoComments", new[] { "UserId" });
            DropIndex("dbo.PhotoComments", new[] { "PhotoId" });
            DropTable("dbo.Videos");
            DropTable("dbo.VideoComments");
            DropTable("dbo.Users");
            DropTable("dbo.Photos");
            DropTable("dbo.PhotoComments");
        }
    }
}
