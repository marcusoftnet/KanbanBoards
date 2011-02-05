using NSubstitute;
using TechTalk.SpecFlow;
using Web.Models.Infrastructure;

namespace Specs.Steps
{
    [Binding]
    public class AutenticationServiceSteps
    {
        private const string AUTHSERVICE_KEY = "AuthenticationService";

        public static IAuthenticationService CurrentAuthenticationService
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(AUTHSERVICE_KEY))
                {
                    var mockedAuthService = Substitute.For<IAuthenticationService>();
                    ScenarioContext.Current.Set(mockedAuthService, AUTHSERVICE_KEY);
                }
                return ScenarioContext.Current.Get<IAuthenticationService>(AUTHSERVICE_KEY);
            }
        }

        [Given(@"I am logged in on the site as (.*)")]
        public void GivenLoggedIn(string userName)
        {
            CurrentAuthenticationService.IsAuthenticated.Returns(true);
            CurrentAuthenticationService.UserName.Returns(userName);
        }
    }
}
