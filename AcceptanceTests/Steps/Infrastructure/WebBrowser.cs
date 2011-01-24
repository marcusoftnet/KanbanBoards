using System;
using System.Configuration;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace AcceptanceTests.Steps.Infrastructure
{
    [Binding]
    public class WebBrowser
    {
        public static Browser Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                    ScenarioContext.Current["browser"] = new IE();
                return (Browser)ScenarioContext.Current["browser"];
            }
        }

        public static void NavigateTo(string relativeUrl)
        {
            var rootUrl = new Uri(ConfigurationManager.AppSettings["RootUrl"]);
            var absoluteUrl = new Uri(rootUrl, relativeUrl);
            Current.GoTo(absoluteUrl);
        }

        [AfterScenario]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
                WebBrowser.Current.Close();
        }
    }
}
