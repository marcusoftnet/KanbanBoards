using System.Web.Mvc;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Models.ViewModels;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardIndexViewModelSteps
    {
        [Then(@"I should see the following Kanbanboards as the most favorited:")]
        public void ThenIShouldSeeTheFollowingKanbanBoardsAsTheMostFavorited(Table table)
        {
            var viewModel = GetTheViewResult();

            var topFavoritedKanbanBoards = viewModel.TopFavoritedKanbanBoards;

            table.CompareToSet(topFavoritedKanbanBoards);
        }

        private static KanbanBoardIndexViewModel GetTheViewResult()
        {
            var viewResult = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            return viewResult.ViewData.Model as KanbanBoardIndexViewModel;
        }
    }
}