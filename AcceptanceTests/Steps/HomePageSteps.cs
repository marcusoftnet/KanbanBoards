using AcceptanceTests.Steps.PageObjects;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class HomePageSteps
    {
        public HomePageSteps()
        {
            ScenarioContext.Current.Set(new HomePage());
        }

        private static HomePage Page { get { return ScenarioContext.Current.Get<HomePage>(); } }

        [When(@"I navigate to to the homepage")]
        public void WhenINavigateToToTheHomepage()
        {
            Page.Visit();
        }

        [Then(@"I should see a list of the 3 most favorited Kanban boards")]
        public void SeeMostFavorited()
        {
            Page.NumberOfFavoritedKanbanBoards.Should().Equal(3);
        }

        [Then(@"I should see a list of the 3 latests added Kanban boards")]
        public void SeeLatestAdded()
        {
            Page.NumberofLatestAddedKanbanBoards.Should().Equal(3);
        }
    }
}
