using System.IO;
using Basin.Selenium;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public static class StepsBase
    {
        [BeforeFeature]
        public static void BeforeFeatureHook()
        {
            BasinEnv.SetConfig($"{Path.GetFullPath("../../../")}/TheInternet.json");
        }

        [BeforeScenario]
        public static void BeforeScenarioHook()
        {
            Browser.Init();
            Pages.Init();
        }

        [AfterScenario]
        public static void AfterScenarioHook()
        {
            Browser.Current?.Quit();
        }
    }
}