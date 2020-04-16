using System;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver _driver;

        [ThreadStatic] public static Wait Wait;

        [ThreadStatic] public static Window Window;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static string Title => Current.Title;

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

        public static void Goto(string url)
        {
            Current.Navigate().GoToUrl(url);
        }

        //TODO: Implement screenshots

        public static void Quit()
        {
            Current.Quit();
        }
    }
}