using System.Collections.Generic;
using Domain;

namespace ReadModel.Model
{
    public class KanbanBoardIndexViewModel
    {
        public IList<KanbanBoard> TopFavoritedKanbanBoards { get; set; }
        public IList<KanbanBoard> LatestAddedKanbanBoards { get; set; }
    }
}