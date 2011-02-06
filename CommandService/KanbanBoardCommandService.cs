using System;
using CommandService.Commands;
using ReadModel;
using Repositories.Storage;

namespace CommandService
{
    public class KanbanBoardCommandService : IKanbanBoardCommandService
    {
        private readonly IKanbanBoardRepository kanbanBoardRepository;

        public KanbanBoardCommandService(IKanbanBoardRepository kanbanBoardRepository)
        {
            this.kanbanBoardRepository = kanbanBoardRepository;
        }

        public void AddKanbanBoard(AddKanbanBoardCommand command)
        {
            var board = new KanbanBoard {
                                User = command.User,
                                Posted = DateTime.Now,
                                TimesFavorited = 0,
                                Title = command.Title,
                                Description = command.Description,
                                Tags = command.Tags
                            };

            kanbanBoardRepository.Add(board);
        }
    }
}