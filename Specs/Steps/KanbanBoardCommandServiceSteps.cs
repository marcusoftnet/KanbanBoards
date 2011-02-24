using CommandService;
using Repositories.Storage;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardCommandServiceSteps
    {
        [BeforeScenario]
        public void Setup()
        {
            ScenarioContext.Current.Set(CreateAKanbanCommandService);
        }

        private static IKanbanBoardCommandService CreateAKanbanCommandService()
        {
            var repository = ScenarioContext.Current.Get<IKanbanBoardRepository>();
            return new KanbanBoardCommandService(repository);
        }
    }
}