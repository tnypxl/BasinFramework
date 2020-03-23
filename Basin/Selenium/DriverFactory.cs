using System;
using Basin.Selenium.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Basin.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browserName, object options = null)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new Chrome((ChromeOptions) options).Current;
                case "firefox":
                    return new Firefox((FirefoxOptions) options).Current;
                case "internet explorer":
                    return new InternetExplorer((InternetExplorerOptions) options).Current;
                default:
                    throw new ArgumentException($"{browserName} not supported.");
            }
        }
    }
}