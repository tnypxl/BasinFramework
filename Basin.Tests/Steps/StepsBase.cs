using System;
using System.IO;
using Basin.Core.Browsers;
using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
            // var myAwesomeBrowser = new ChromeBrowser()
            //     .CreateDriverService()
            //     .CreateDriverOptions();

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