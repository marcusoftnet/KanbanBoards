using System.Collections.Generic;
using System.Linq;
using Domain;
using NSubstitute;
using Repositories.Storage;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardRepositorySteps
    {
        private IKanbanBoardRepository singleKanbanBoardRepository;

        [BeforeScenario]
        public void Setup()
        {
            ScenarioContext.Current.Set(() => singleKanbanBoardRepository ?? (singleKanbanBoardRepository = Substitute.For<IKanbanBoardRepository>()));
        }

        public static void AddBoardToReturn(KanbanBoard newBoardToReturn)
        {
            var kanbanBoardRepository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            var currentBoards = kanbanBoardRepository.GetAllKanbanBoards().ToList();
            currentBoards.Add(newBoardToReturn);
            kanbanBoardRepository.GetAllKanbanBoards().Returns(currentBoards);
        }

        [Given(@"the following Kanbanboards")]
        public void GivenTheFollowingKanbanBoards(Table table)
        {
            var kanbanBoards = table.CreateSet<KanbanBoard>();
            var kanbanBoardRepository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            kanbanBoardRepository.GetAllKanbanBoards().Returns(kanbanBoards);
        }
    }
}