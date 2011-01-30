using System.Data.Entity;
using ReadModel.Model;

namespace ReadModel.Storage
{
    public partial class KanbanBoardsDbContext : DbContext
    {
        // If you want Entity Framework to drop and regenerate your database automatically whenever you change
        // your model schema, add the following line to the Application_Start() method in Global.asax.cs:
        // DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<WebContext>());

		public DbSet< KanbanBoard> KanbanBoards { get; set; }
    }
}