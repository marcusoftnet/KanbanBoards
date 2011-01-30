using System.Linq;
using ReadModel.Model;
using ReadModel.Storage;

namespace ReadModel
{
    public class KanbanBoardReadService : IKanbanBoardReadService
    {
        private readonly IKanbanBoardRepository kanbanBoardRepository;

        public KanbanBoardReadService(IKanbanBoardRepository repository)
        {
            kanbanBoardRepository = repository;
        }

        public KanbanBoardIndexViewModel GetIndexViewModel()
        {
            return new KanbanBoardIndexViewModel
            {
                TopFavoritedKanbanBoards =
                    kanbanBoardRepository.GetAllKanbanBoards()
                    .OrderByDescending(x => x.TimesFavorited)
                    .Take(3)
                    .ToList(),
                LatestAddedKanbanBoards =
                    kanbanBoardRepository.GetAllKanbanBoards()
                    .OrderByDescending(x => x.Posted)
                    .Take(3)
                    .ToList()
            };
        }
    }
}