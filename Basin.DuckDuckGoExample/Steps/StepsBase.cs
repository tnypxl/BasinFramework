using System;
using System.IO;
using Basin.Selenium;
using Basin.Selenium.Builders;
using Basin.Selenium.Drivers;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Basin.DuckDuckGoExample.Steps
{
    [Binding]
    public class StepsBase
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
            DriverFactory.Builders.Add("fast firefox", () =>
            {
                static FirefoxBuilder Builder()
                {
                    var builder = new FirefoxBuilder();
                    builder.CreateService();
                    builder.CreateOptions();
                    builder.DriverOptions.PageLoadStrategy = PageLoadStrategy.Eager;

                    return builder;
                }

                return Builder();
            });
            
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
