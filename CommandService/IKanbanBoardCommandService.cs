using CommandService.Commands;

namespace CommandService
{
    public interface IKanbanBoardCommandService
    {
        void AddKanbanBoard(AddKanbanBoardCommand command);
    }
}
