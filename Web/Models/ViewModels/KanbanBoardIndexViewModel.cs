using System.Collections.Generic;
using Web.Models.Domain;

namespace Web.Models.ViewModels
{
    public class KanbanBoardIndexViewModel
    {
        public IEnumerable<KanbanBoard> TopFavoritedKanbanBoards { get; set; }
        public IEnumerable<KanbanBoard> LatestAddedKanbanBoards { get; set; }
    }
}