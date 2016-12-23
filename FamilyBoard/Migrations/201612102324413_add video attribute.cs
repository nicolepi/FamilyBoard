namespace FamilyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvideoattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Video_Id", c => c.Int());
            CreateIndex("dbo.Files", "Video_Id");
            AddForeignKey("dbo.Files", "Video_Id", "dbo.Videos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Video_Id", "dbo.Videos");
            DropIndex("dbo.Files", new[] { "Video_Id" });
            DropColumn("dbo.Files", "Video_Id");
        }
    }
}
