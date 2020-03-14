using System;
using Basin.Utils.CssToXpath;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver _driver;

        [ThreadStatic] public static Wait Wait;

        [ThreadStatic] public static Window Window;

        public static void Init(string browserName, int waitSeconds = 10)
        {
            if (string.IsNullOrEmpty(browserName))
                throw new ArgumentException(
                    "Expected value to be 'chrome', 'firefox', or 'internet explorer'", nameof(browserName));
            
            _driver = DriverFactory.Build(browserName);
            Wait = new Wait(waitSeconds);
            Window = new Window();
            Window.Maximize();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static string Title => Current.Title;

        public static void Goto(string url) => Current.Navigate().GoToUrl(url);

        public static Element Locate(By by)
        {
            var element = Wait.Until(driver => driver.FindElement(by));
            return new Element(element)
            {
                FoundBy = by
            };
        }

        public static Element Locate(string css)
        {
            var byXPath = By.XPath(Converter.CSSToXPath(css));
            var element = Wait.Until(driver => driver.FindElement(byXPath));
            return new Element(element)
            {
                FoundBy = byXPath
            };
        }
        
        public static Elements LocateAll(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        // TODO: Implement screenshots
        // public static void TakeScreenshot(string imageName)
        // {
        //     ...
        // }

        public static void Quit()
        {
            Current.Quit();
        }
    }
}