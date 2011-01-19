using NSubstitute;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Models.Domain;
using Web.Storage;

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