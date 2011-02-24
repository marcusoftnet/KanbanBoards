using ReadModel;
using Repositories.Storage;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardRepositorySteps
    {
        private TestKanbanBoardRepository singleKanbanBoardRepository;

        [BeforeScenario]
        public void Setup()
        {
            ScenarioContext.Current.Set<IKanbanBoardRepository>(CreateAndReturnASingleInstanceOfTheRepository);
            ScenarioContext.Current.Set<TestKanbanBoardRepository>(CreateAndReturnASingleInstanceOfTheRepository);
        }

        private TestKanbanBoardRepository CreateAndReturnASingleInstanceOfTheRepository()
        {
            return singleKanbanBoardRepository ?? (singleKanbanBoardRepository = new TestKanbanBoardRepository());
        }

        [Given(@"the following Kanbanboards")]
        public void GivenTheFollowingKanbanBoards(Table table)
        {
            var kanbanBoardRepository = ScenarioContext.Current.Get<TestKanbanBoardRepository>();
            kanbanBoardRepository.Clear();
            kanbanBoardRepository.AddRange(table.CreateSet<KanbanBoard>());
        }
    }
}