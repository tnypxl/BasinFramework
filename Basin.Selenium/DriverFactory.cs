using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium.Browsers;

namespace Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browserName, object options = null)
        {
            return browserName.ToLower() switch
            {
                "chrome" => new Chrome((ChromeOptions)options).Current,
                "firefox" => new Firefox((FirefoxOptions)options).Current,
                "internet explorer" => new InternetExplorer((InternetExplorerOptions)options).Current,
                _ => throw new System.ArgumentException($"{browserName} not supported.")
            };
        }
    }
}