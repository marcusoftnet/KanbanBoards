using System.Collections.Generic;

namespace ReadModel
{
    public class KanbanBoardIndexViewModel
    {
        public IList<KanbanBoard> TopFavoritedKanbanBoards { get; set; }
        public IList<KanbanBoard> LatestAddedKanbanBoards { get; set; }
    }
}