using System.Collections.Generic;

namespace ReadModel.Model
{
    public class KanbanBoardIndexViewModel
    {
        public IList<KanbanBoard> TopFavoritedKanbanBoards { get; set; }
        public IList<KanbanBoard> LatestAddedKanbanBoards { get; set; }
    }
}