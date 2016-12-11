namespace FamilyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videofiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Video_Id", "dbo.Videos");
            DropIndex("dbo.Files", new[] { "Video_Id" });
            CreateTable(
                "dbo.VideoFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .Index(t => t.VideoId);
            
            DropColumn("dbo.Files", "Video_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "Video_Id", c => c.Int());
            DropForeignKey("dbo.VideoFiles", "VideoId", "dbo.Videos");
            DropIndex("dbo.VideoFiles", new[] { "VideoId" });
            DropTable("dbo.VideoFiles");
            CreateIndex("dbo.Files", "Video_Id");
            AddForeignKey("dbo.Files", "Video_Id", "dbo.Videos", "Id");
        }
    }
}
