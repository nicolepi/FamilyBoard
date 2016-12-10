namespace FamilyBoard
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class FamilyBoardModel : DbContext
    {
        // Your context has been configured to use a 'FamilyBoardModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FamilyBoard.FamilyBoardModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FamilyBoardModel' 
        // connection string in the application configuration file.
        public FamilyBoardModel()
            : base("name=FamilyBoardModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<PhotoComment> PhotoComments { get; set; }
        public virtual DbSet<VideoComment> VideoComments { get; set; }
        public virtual DbSet<TodoList> TodoLists { get; set; }
        public DbSet<File> Files { get; set; } //added for photo upload function

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }

    
   

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}