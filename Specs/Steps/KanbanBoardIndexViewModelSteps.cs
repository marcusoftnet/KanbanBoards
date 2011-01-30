using System.Web.Mvc;
using ReadModel.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardIndexViewModelSteps
    {
        [Then(@"I should see the following Kanbanboards as the most favorited:")]
        public void AsMostFavorited(Table table)
        {
            var viewModel = GetTheViewResult();

            var topFavoritedKanbanBoards = viewModel.TopFavoritedKanbanBoards;

            table.CompareToSet(topFavoritedKanbanBoards);
        }

        [Then(@"I should see the following Kanbanboards as the latests additions:")]
        public void AsLatestAdditions(Table table)
        {
            var viewModel = GetTheViewResult();

            var latestsAdded = viewModel.LatestAddedKanbanBoards;

            table.CompareToSet(latestsAdded);

        }


        private static KanbanBoardIndexViewModel GetTheViewResult()
        {
            var viewResult = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            return viewResult.ViewData.Model as KanbanBoardIndexViewModel;
        }
    }
}