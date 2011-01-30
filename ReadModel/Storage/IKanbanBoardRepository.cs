using System.Collections.Generic;
using ReadModel.Model;

namespace ReadModel.Storage
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