using AcceptanceTests.Steps.Infrastructure;
using Should.Fluent;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class HomePageSteps
    {
        [When(@"I navigate to to the homepage")]
        public void WhenINavigateToToTheHomepage()
        {
            WebBrowser.NavigateTo("/");
        }

        [Then(@"I should see a list of the 3 most favorited Kanban boards")]
        public void ThenIShouldSeeAListOfThe3MostFavoritedKanbanBoards()
        {
            var top = WebBrowser.Current.Div(Find.ById("topKanbanBoards"));
            top.Divs.Count.Should().Equal(3);
        }

        [Then(@"I should see a list of the 3 latests added Kanban boards")]
        public void ThenIShouldSeeAListOfThe3LatestsAddedKanbanBoards()
        {
            var top = WebBrowser.Current.Div(Find.ById("latestKanbanBoards"));
            top.Divs.Count.Should().Equal(3);
        }
    }
}
