using System.Collections.Generic;
using ReadModel;

namespace Repositories.Storage
{
    public interface IKanbanBoardRepository
    {
        void Add(KanbanBoard post);
        void Delete(int id);
        IEnumerable<KanbanBoard> GetAllKanbanBoards();
        KanbanBoard GetById(int id);
        void Save();
    }
}