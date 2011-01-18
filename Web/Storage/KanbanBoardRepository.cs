using System.Collections.Generic;
using System.Linq;
using Web.Models.Domain;

namespace Web.Storage
{ 
    public class KanbanBoardRepository : IKanbanBoardRepository
    {
        private readonly KanbanBoardsDbContext context = new KanbanBoardsDbContext();

        public IEnumerable<KanbanBoard> GetAllKanbanBoards()
        {
            return context.KanbanBoards.ToList();
        }

        public KanbanBoard GetById(int id)
        {
            return this.context.KanbanBoards.Find(id);
        }

        public void Add(KanbanBoard kanbanboard)
        {
            context.KanbanBoards.Add(kanbanboard);
        }

        public void Delete(int id)
        {
            var d = context.KanbanBoards.Find(id);
            context.KanbanBoards.Remove(d);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}