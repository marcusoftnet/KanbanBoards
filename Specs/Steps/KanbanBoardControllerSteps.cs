using System.Web.Mvc;
using CommandService;
using CommandService.Commands;
using Domain;
using ReadModel;
using ReadModel.Model;
using Should.Fluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Controllers;
using Web.Models.Infrastructure;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardControllerSteps
    {
        private static KanbanBoardController CreateController()
        {
            var authService = ScenarioContext.Current.Get<IAuthenticationService>();
            var repository = KanbanBoardRepositorySteps.CurrentKanbanBoardRepository;

            var readService = new KanbanBoardReadService(repository);
            var commandService = new KanbanBoardCommandService(repository);
            
            return new KanbanBoardController(readService, authService, commandService);
        }

        [When(@"I navigate to to the homepage")]
        public void WhenIGoToToTheHomepage()
        {
            var controller = CreateController();
            MvcSteps.LatestActionResult = controller.Index();
        }

        [When(@"I navigate to to the create new kanbanboard page")]
        public void WhenIGoToTheCreatePage()
        {
            var controller = CreateController();
            MvcSteps.LatestActionResult = controller.Create();
        }

        [When(@"I am redirected to the MyBoards page")]
        [When(@"I navigate to the MyBoards page")]
        public void NavigateMyBoards()
        {
            var controller = CreateController();
            MvcSteps.LatestActionResult = controller.MyBoards();
        }

        [Then(@"the following boards should be listed as my boards:")]
        public void ListedAsMyBoards(Table table)
        {
            MvcSteps.LatestActionResult.Should().Be.OfType(typeof(ViewResult));
            var viewResult = MvcSteps.LatestActionResult as ViewResult;

            viewResult.ViewData.Model.Should().Be.OfType(typeof(MyBoardsViewModel));
            var vm = viewResult.ViewData.Model as MyBoardsViewModel;

            table.CompareToSet<KanbanBoard>(vm.Boards);
        }

        [When(@"I submit a board with the following information")]
        public void WhenIEnterTheFollowingInformation(Table enteredInformation)
        {
            var createVm = enteredInformation.CreateInstance<AddKanbanBoardCommand>();
            var controller = CreateController();
            MvcSteps.LatestActionResult = controller.Create(createVm);

            KanbanBoardRepositorySteps.AddBoardToReturn(
                new KanbanBoard{Title = createVm.Title, User = createVm.User});
        }
    }
}