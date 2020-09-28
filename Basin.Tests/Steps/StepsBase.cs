using System.IO;
using Basin.PageObjects;
using Basin.Selenium;
using Basin.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public class StepsBase
    {
        [BeforeFeature]
        public static void BeforeFeatureHook()
        {
            BasinEnv.SetConfig($"{Path.GetFullPath("../../../")}/TheInternet.json");
            Pages.Add(new HomePage());
            Pages.Add(new AddRemoveElementsExamplePage());
            Pages.Add(new LargeAndDeepDomExamplePage());
            Pages.Add(new DynamicControlsExamplePage());
        }

        [BeforeScenario]
        public void BeforeScenarioHook()
        {
            BrowserSession.Init();
        }

        [AfterScenario]
        public void AfterScenarioHook()
        {
            BrowserSession.Quit();
        }
    }
}