using System.Web.Mvc;
using CommandService;
using CommandService.Commands;
using ReadModel;
using Web.Models.Infrastructure;

namespace Web.Controllers
{
    public class KanbanBoardController : Controller
    {
        private readonly IKanbanBoardReadService readService;
        private readonly IAuthenticationService authenticationService;
        private readonly IKanbanBoardCommandService commandService;

        public KanbanBoardController(IKanbanBoardReadService kanbanBoardReadService,
            IAuthenticationService authenticationService,
            IKanbanBoardCommandService commandService)
        {
            readService = kanbanBoardReadService;
            this.authenticationService = authenticationService;
            this.commandService = commandService;
        }

        public ViewResult Index()
        {
            return View("Index", readService.GetIndexViewModel());
        }

        public ActionResult Create()
        {
            return View("Create", new AddKanbanBoardCommand());
        }

        [HttpPost]
        public ActionResult Create(AddKanbanBoardCommand addKanbanBoardCommand)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", new AddKanbanBoardCommand());                
            }

            addKanbanBoardCommand.User = authenticationService.UserName;
            commandService.AddKanbanBoard(addKanbanBoardCommand);

            return RedirectToAction("MyBoards");
        }

        public ActionResult MyBoards()
        {
            var vm = readService.GetMyBoardsViewModel(authenticationService.UserName);
            return View("MyBoards", vm);
        }
    }
}