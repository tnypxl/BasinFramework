using System;
using Basin.Selenium;
using TechTalk.SpecFlow;

namespace Basin.DuckDuckGoExample.Steps
{
    [Binding]
    public class StepsBase
    {
        private static readonly string ProjectPath = AppDomain.CurrentDomain.BaseDirectory.Replace(
            "\\bin\\Debug\\netcoreapp3.1", 
            "");

        public static Basin Config => Basin.FromJson($"{ProjectPath}/DuckDuckGo.json");

        [BeforeFeature]
        public static void BeforeFeatureHook()
        {
            Driver.Init(Config.Driver.Browser, Config.Driver.Timeout);
            Pages.Init();
        }

        [AfterFeature]
        public static void AfterFeatureHook()
        {
            Driver.Current?.Quit();
        }
    }
}
