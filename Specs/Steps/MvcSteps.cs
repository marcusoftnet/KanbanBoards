using System.Web.Mvc;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class MvcSteps
    {
        [Then(@"I should be on the (.*) page")]
        public void ThenIShouldBeOnTheIndexPage(string viewName)
        {
            var actionResult = ScenarioContext.Current.Get<ActionResult>();
            actionResult.Should().Be.OfType(typeof(ViewResult));

            var viewResult = actionResult as ViewResult;
            viewResult.ViewName.Should().Equal(viewName);
        }

        [Then(@"I should be redirected the (.*) page")]
        public void RedirectedToPage(string viewName)
        {
            var actionResult = ScenarioContext.Current.Get<ActionResult>();
            actionResult.Should().Be.OfType(typeof(RedirectToRouteResult));

            var redirectResult = actionResult as RedirectToRouteResult;
            redirectResult.RouteValues["action"].Should().Equal(viewName);
        }
    }
}