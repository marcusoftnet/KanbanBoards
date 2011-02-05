using ReadModel.Model;

namespace ReadModel
{
    public interface IKanbanBoardReadService
    {
        KanbanBoardIndexViewModel GetIndexViewModel();
        MyBoardsViewModel GetMyBoardsViewModel(string userName);
    }
}