using System.Collections.Generic;
using System.Linq;
using ReadModel;
using Repositories.Storage;

namespace Specs.Steps
{
    public class TestKanbanBoardRepository : List<KanbanBoard>, IKanbanBoardRepository
    {
        public void Delete(int id)
        {
            var itemToRemove = this.Single(x => x.ID == id);
            Remove(itemToRemove);
        }

        public IEnumerable<KanbanBoard> GetAllKanbanBoards()
        {
            return this;
        }

        public KanbanBoard GetById(int id)
        {
            return this.First(x => x.ID == id);
        }

        public void Save()
        {
            // is this necessary yet? when does the need to call this method happen? 
        }
    }
}