using System;
using System.Data.Entity.Database;
using ReadModel;

namespace Repositories.Storage
{
    public class KanbanBoardDbIntializerWith5SeededBoards 
        : DropCreateDatabaseIfModelChanges<KanbanBoardsDbContext>
    {
        protected override void Seed(KanbanBoardsDbContext context)
        {
            context.KanbanBoards.Add(new KanbanBoard { 
                Title = "Demo 1", User = "Marcus", Description = "Demo 1 description",
                TimesFavorited = 100, Posted = DateTime.Now.AddMonths(-10) });
            
            context.KanbanBoards.Add(new KanbanBoard { 
                Title = "Demo 2", User = "David", Description = "Demo 2 description", 
                TimesFavorited = 10000, Posted = DateTime.Now.AddMonths(-5) });
            
            context.KanbanBoards.Add(new KanbanBoard {
                Title = "Demo 3", User = "Christophe", Description = "Demo 3 description", 
                TimesFavorited = 500, Posted = DateTime.Now.AddYears(-1)});
            
            context.KanbanBoards.Add(new KanbanBoard {
                Title = "Demo 4", User = "Joakim", Description = "Demo 4 description", 
                TimesFavorited = 300, Posted = DateTime.Now.AddMonths(-3)});
            
            context.KanbanBoards.Add(new KanbanBoard {
                Title = "Demo 5", User = "Marcus", Description = "Demo 5 description", 
                TimesFavorited = 10, Posted = DateTime.Now.AddMonths(-1)});

            context.SaveChanges();
        }
    }
    
}
