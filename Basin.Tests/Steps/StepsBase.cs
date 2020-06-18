using System.IO;
using Basin.Selenium;
using Basin.Selenium.Builders;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public static class StepsBase
    {
        private static readonly string ConfigPath = Path.GetFullPath("../../../");

        [BeforeFeature]
        public static void BeforeFeatureHook()
        {
            BSN.SetConfig($"{ConfigPath}/DuckDuckGo.json");
        }

        [BeforeScenario]
        public static void BeforeScenarioHook()
        {
            Driver.Init();
            Pages.Init();
        }

        [AfterScenario]
        public static void AfterScenarioHook()
        {
            Driver.Current?.Quit();
        }
    }
}