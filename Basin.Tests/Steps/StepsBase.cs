using System.IO;
using Basin.Config.Interfaces;
using Basin.Selenium;
using Basin.Selenium.Builders;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public static class StepsBase
    {
        [BeforeFeature]
        public static void BeforeFeatureHook()
        {
            BSN.SetConfig($"{Path.GetFullPath("../../../")}/TheInternet.json");
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