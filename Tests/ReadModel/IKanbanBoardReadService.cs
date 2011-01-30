using Web.Models.ViewModels;

namespace Tests.ReadModel
{
    public interface IKanbanBoardReadService
    {
        KanbanBoardIndexViewModel GetIndexViewModel();
    }
}