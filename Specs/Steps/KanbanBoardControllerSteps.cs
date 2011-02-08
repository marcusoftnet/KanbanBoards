using System.Web.Mvc;
using CommandService;
using CommandService.Commands;
using Domain;
using ReadModel;
using ReadModel.Model;
using Repositories.Storage;
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
            var repository = ScenarioContext.Current.Get<IKanbanBoardRepository>();

            var readService = new KanbanBoardReadService(repository);
            var commandService = new KanbanBoardCommandService(repository);
            
            return new KanbanBoardController(readService, authService, commandService);
        }

        [When(@"I navigate to to the homepage")]
        public void WhenIGoToToTheHomepage()
        {
            var controller = CreateController();
            var result = controller.Index();
            ScenarioContext.Current.Set<ActionResult>(result);
        }

        [When(@"I navigate to to the create new kanbanboard page")]
        public void WhenIGoToTheCreatePage()
        {
            var controller = CreateController();
            var result = controller.Create();
            ScenarioContext.Current.Set(result);
        }

        [When(@"I am redirected to the MyBoards page")]
        [When(@"I navigate to the MyBoards page")]
        public void NavigateMyBoards()
        {
            var controller = CreateController();
            var result = controller.MyBoards();
            ScenarioContext.Current.Set(result);
        }

        [Then(@"the following boards should be listed as my boards:")]
        public void ListedAsMyBoards(Table table)
        {
            var actionResult = ScenarioContext.Current.Get<ActionResult>();
            actionResult.Should().Be.OfType(typeof(ViewResult));
            var viewResult = actionResult as ViewResult;

            viewResult.ViewData.Model.Should().Be.OfType(typeof(MyBoardsViewModel));
            var vm = viewResult.ViewData.Model as MyBoardsViewModel;

            table.CompareToSet<KanbanBoard>(vm.Boards);
        }

        [When(@"I submit a board with the following information")]
        public void WhenIEnterTheFollowingInformation(Table enteredInformation)
        {
            var createVm = enteredInformation.CreateInstance<AddKanbanBoardCommand>();
            var controller = CreateController();
            var viewResult = controller.Create(createVm);

            ScenarioContext.Current.Set(viewResult);
            
            KanbanBoardRepositorySteps.AddBoardToReturn(
                new KanbanBoard{Title = createVm.Title, User = createVm.User});
        }
    }
}