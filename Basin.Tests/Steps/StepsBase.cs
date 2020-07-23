using System;
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
            Pages.Add(new LargeAndDeepDOMExamplePage());
        }

        [BeforeScenario]
        public void BeforeScenarioHook()
        {
            // BasinEnv.UseBrowser("Chrome");
            Console.WriteLine(BasinEnv.Pages.Count);
            BrowserSession.Init();
        }

        [AfterScenario]
        public void AfterScenarioHook()
        {
            BrowserSession.Current?.Quit();
        }
    }
}