using ReadModel;

namespace ReadService
{
    public interface IKanbanBoardReadService
    {
        KanbanBoardIndexViewModel GetIndexViewModel();
        MyBoardsViewModel GetMyBoardsViewModel(string userName);
    }
}