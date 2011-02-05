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
        private const string REPOSITORY_KEY = "KanbanBoardsRepository";

        public static IKanbanBoardRepository CurrentKanbanBoardRepository
        {
            get
            {
                if(!ScenarioContext.Current.ContainsKey(REPOSITORY_KEY))
                {
                    var mockedRepository = Substitute.For<IKanbanBoardRepository>();
                    ScenarioContext.Current.Set(mockedRepository, REPOSITORY_KEY);
                }
                return ScenarioContext.Current.Get<IKanbanBoardRepository>(REPOSITORY_KEY);
            }
        }

        public static void AddBoardToReturn(KanbanBoard newBoardToReturn)
        {
            var currentBoards = CurrentKanbanBoardRepository.GetAllKanbanBoards().ToList();
            currentBoards.Add(newBoardToReturn);
            CurrentKanbanBoardRepository.GetAllKanbanBoards().Returns(currentBoards);
        }

        [Given(@"the following Kanbanboards")]
        public void GivenTheFollowingKanbanBoards(Table table)
        {
            var kanbanBoards = table.CreateSet<KanbanBoard>();
            CurrentKanbanBoardRepository.GetAllKanbanBoards().Returns(kanbanBoards);
        }
    }
}