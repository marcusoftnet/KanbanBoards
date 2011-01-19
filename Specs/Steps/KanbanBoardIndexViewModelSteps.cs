using System.Linq;
using System.Web.Mvc;
using Should.Fluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Models.Domain;
using Web.Models.ViewModels;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardIndexViewModelSteps
    {
        [Then(@"I should see the following Kanbanboards as the most favorited:")]
        public void ThenIShouldSeeTheFollowingKanbanBoardsAsTheMostFavorited(Table table)
        {
            var viewResult = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            var viewModel = viewResult.ViewData.Model as KanbanBoardIndexViewModel;

            var boardsFromStep = table.CreateSet<KanbanBoard>().ToList();

            var topFavoritedKanbanBoards = viewModel.TopFavoritedKanbanBoards;

            topFavoritedKanbanBoards.Count.Should().Equal(boardsFromStep.Count);

            for (var i = 0; i < table.RowCount; i++)
            {
                topFavoritedKanbanBoards[i].Title.Should().Equal(boardsFromStep[i].Title);
                topFavoritedKanbanBoards[i].Posted.Should().Equal(boardsFromStep[i].Posted);
                topFavoritedKanbanBoards[i].User.Should().Equal(boardsFromStep[i].User);
            }
        }
    }
}