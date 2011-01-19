using System.Linq;
using System.Web.Mvc;
using NSubstitute;
using Should.Fluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Controllers;
using Web.Models.Domain;
using Web.Models.ViewModels;
using Web.Storage;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardSteps
    {
        [Given(@"the following Kanbanboards")]
        public void GivenTheFollowingKanbanBoards(Table table)
        {
            var kanbanBoards = table.CreateSet<KanbanBoard>();
            
            var mockedRepository = Substitute.For<IKanbanBoardRepository>();
            mockedRepository.GetAllKanbanBoards().Returns(kanbanBoards);

            ScenarioContext.Current.Set<IKanbanBoardRepository>(mockedRepository);
        }

        [When(@"I to to the homepage")]
        public void WhenIToToTheHomepage()
        {
            var kanbanBoardRepository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            var kanbanBoardController = new KanbanBoardController(kanbanBoardRepository);

            var viewResult = kanbanBoardController.Index() as ViewResult;
            viewResult.Should().Not.Be.Null();

            var viewModel = viewResult.ViewData.Model as KanbanBoardIndexViewModel;
            viewModel.Should().Not.Be.Null();

            ScenarioContext.Current.Set(viewModel);
        }

        [Then(@"I should see the following Kanbanboards as the most favorited:")]
        public void ThenIShouldSeeTheFollowingKanbanBoardsAsTheMostFavorited(Table table)
        {
            var boardsFromStep = table.CreateSet<KanbanBoard>().ToList();
            var viewModel = ScenarioContext.Current.Get<KanbanBoardIndexViewModel>();
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
