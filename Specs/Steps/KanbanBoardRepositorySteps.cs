using System.Collections.Generic;
using System.Linq;
using Domain;
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

    public class TestKanbanBoardRepository : List<KanbanBoard>, IKanbanBoardRepository
    {
        public void Delete(int id)
        {
            var itemToRemove = this.Single(x => x.ID == id);
            Remove(itemToRemove);
        }

        public IEnumerable<KanbanBoard> GetAllKanbanBoards()
        {
            return this;
        }

        public KanbanBoard GetById(int id)
        {
            return this.First(x => x.ID == id);
        }

        public void Save()
        {
            // is this necessary yet? when does the need to call this method happen? 
        }
    }
}