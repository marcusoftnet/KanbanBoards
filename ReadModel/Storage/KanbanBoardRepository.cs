using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ReadModel.Model;

namespace ReadModel.Storage
{
    [DebuggerNonUserCode]
    public class KanbanBoardRepository : IKanbanBoardRepository
    {
        private readonly KanbanBoardsDbContext context = new KanbanBoardsDbContext();

        public IEnumerable<KanbanBoard> GetAllKanbanBoards()
        {
            return context.KanbanBoards.ToList();
        }

        public KanbanBoard GetById(int id)
        {
            return context.KanbanBoards.Find(id);
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