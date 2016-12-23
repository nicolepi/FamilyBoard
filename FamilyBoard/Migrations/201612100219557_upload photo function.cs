namespace FamilyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploadphotofunction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Files", new[] { "PhotoId" });
            DropTable("dbo.Files");
        }
    }
}
