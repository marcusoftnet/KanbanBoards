using System.Web.Mvc;
using ReadModel;

namespace Web.Controllers
{   
    public class KanbanBoardController : Controller
    {
        private readonly IKanbanBoardReadService readService;

        public KanbanBoardController(IKanbanBoardReadService kanbanBoardReadService)
        {
            readService = kanbanBoardReadService;
        }

        public ViewResult Index()
        {
            return View("Index", readService.GetIndexViewModel());
        }

    }
}