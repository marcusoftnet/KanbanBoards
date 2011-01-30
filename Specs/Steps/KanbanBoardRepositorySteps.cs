using NSubstitute;
using ReadModel.Model;
using ReadModel.Storage;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public class KanbanBoardRepositorySteps
    {
        [Given(@"the following Kanbanboards")]
        public void GivenTheFollowingKanbanBoards(Table table)
        {
            var kanbanBoards = table.CreateSet<KanbanBoard>();

            var mockedRepository = Substitute.For<IKanbanBoardRepository>();
            mockedRepository.GetAllKanbanBoards().Returns(kanbanBoards);

            ScenarioContext.Current.Set(mockedRepository);
        }
    }
}