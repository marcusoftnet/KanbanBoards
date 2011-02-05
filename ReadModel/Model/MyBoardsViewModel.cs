using System.Collections.Generic;
using Domain;

namespace ReadModel.Model
{
    public class MyBoardsViewModel
    {
        public IList<KanbanBoard> Boards { get;  set; }
    }
}