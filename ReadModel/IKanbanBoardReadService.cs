using ReadModel.Model;

namespace ReadModel
{
    public interface IKanbanBoardReadService
    {
        KanbanBoardIndexViewModel GetIndexViewModel();
    }
}