using System.Web.Mvc;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class MvcSteps
    {
        public static ActionResult LatestActionResult
        {
            get { return ScenarioContext.Current.Get<ActionResult>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        [Then(@"I should be on the (.*) page")]
        public void ThenIShouldBeOnTheIndexPage(string viewName)
        {
            LatestActionResult.Should().Be.OfType(typeof (ViewResult));

            var viewResult = LatestActionResult as ViewResult;
            viewResult.ViewName.Should().Equal(viewName);
        }

        [Then(@"I should be redirected the (.*) page")]
        public void RedirectedToPage(string viewName)
        {
            LatestActionResult.Should().Be.OfType(typeof(RedirectToRouteResult));

            var redirectResult = LatestActionResult as RedirectToRouteResult;
            redirectResult.RouteValues["action"].Should().Equal(viewName);
        }

       
    }
}