using System.Collections.Generic;
using Web.Models.Domain;

namespace Web.Models.ViewModels
{
    public class KanbanBoardIndexViewModel
    {
        public IList<KanbanBoard> TopFavoritedKanbanBoards { get;  set; }
    }
}