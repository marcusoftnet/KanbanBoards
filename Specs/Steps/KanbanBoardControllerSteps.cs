using System.Web.Mvc;
using TechTalk.SpecFlow;
using Web.Controllers;
using Web.Storage;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardControllerSteps
    {
        [When(@"I to to the homepage")]
        public void WhenIToToTheHomepage()
        {
            var kanbanBoardRepository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            var kanbanBoardController = new KanbanBoardController(kanbanBoardRepository);

            var viewResult = kanbanBoardController.Index();

            ScenarioContext.Current.Set<ActionResult>(viewResult);
        }
    }
}