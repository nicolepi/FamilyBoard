namespace FamilyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todolistrefine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoLists", "Done", c => c.Boolean(nullable: false));
            AddColumn("dbo.TodoLists", "Content", c => c.String());
            AddColumn("dbo.TodoLists", "DateCompleted", c => c.String());
            DropColumn("dbo.TodoLists", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TodoLists", "Title", c => c.String());
            DropColumn("dbo.TodoLists", "DateCompleted");
            DropColumn("dbo.TodoLists", "Content");
            DropColumn("dbo.TodoLists", "Done");
        }
    }
}
