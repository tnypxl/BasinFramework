using System.IO;
using Browsers = Basin.Core.Browsers;
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
            Browser.Init(RemoteFirefox());
            Pages.Init();
        }

        [AfterScenario]
        public static void AfterScenarioHook()
        {
            Browser.Current?.Quit();
        }

        private static Browsers.FirefoxBrowser RemoteFirefox()
        {
            var browser = new Browsers.FirefoxBrowser();

            browser.CreateDriverService();
            browser.CreateDriverOptions();
            browser.FirefoxDriverService.Host = "localhost";
            browser.FirefoxDriverService.Port = 4444;
            browser.FirefoxOptions.BrowserVersion = "78.0";
            browser.FirefoxOptions.PlatformName = "linux";

            return browser;
        }

    }
}