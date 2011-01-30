using AcceptanceTests.Steps.Infrastructure;
using WatiN.Core;

namespace AcceptanceTests.Steps.PageObjects
{
    public class HomePage : PageObjectBase
    {
        public HomePage() : base(WebBrowser.Current, "/") { }

        public int NumberOfFavoritedKanbanBoards
        {
            get { return Browser.Div(Find.ById("topKanbanBoards")).Divs.Count; }
        }

        public int NumberofLatestAddedKanbanBoards
        {
            get { return Browser.Div(Find.ById("latestKanbanBoards")).Divs.Count; }
        }
    }
}
