using System.Web.Mvc;
using ReadModel;
using ReadModel.Storage;
using TechTalk.SpecFlow;
using Web.Controllers;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardControllerSteps
    {
        [When(@"I navigate to to the homepage")]
        public void WhenIGoToToTheHomepage()
        {
            var repository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            var readService = new KanbanBoardReadService(repository);
            var kanbanBoardController = new KanbanBoardController(readService);

            var viewResult = kanbanBoardController.Index();

            ScenarioContext.Current.Set<ActionResult>(viewResult);
        }
    }
}