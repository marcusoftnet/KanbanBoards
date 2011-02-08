using NSubstitute;
using TechTalk.SpecFlow;
using Web.Models.Infrastructure;

namespace Specs.Steps
{
    [Binding]
    public class AutenticationServiceSteps
    {
        private IAuthenticationService authenticationServiceSingleton;

        [BeforeScenario]
        public void Setup()
        {
            ScenarioContext.Current.Set(() => authenticationServiceSingleton ?? (authenticationServiceSingleton = Substitute.For<IAuthenticationService>()));
        }

        [Given(@"I am logged in on the site as (.*)")]
        public void GivenLoggedIn(string userName)
        {
            var authenticationService = ScenarioContext.Current.Get<IAuthenticationService>();
            authenticationService.IsAuthenticated.Returns(true);
            authenticationService.UserName.Returns(userName);
        }
    }
}
