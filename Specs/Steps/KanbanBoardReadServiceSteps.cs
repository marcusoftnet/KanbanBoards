using ReadModel;
using Repositories.Storage;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardReadServiceSteps
    {
        [BeforeScenario]
        public void Setup()
        {
            ScenarioContext.Current.Set(CreateAKanbanBoardReadService);
        }

        private static IKanbanBoardReadService CreateAKanbanBoardReadService()
        {
            var repository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            return new KanbanBoardReadService(repository);
        }
    }
}