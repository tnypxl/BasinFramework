using System;
using Basin.Selenium.Interfaces;
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

        public static void Init()
        {
            _driver = BSN.Config.Driver.Host == null
                ? DriverFactory.Builders[BSN.Config.Driver.Browser].Invoke().GetDriver
                : DriverFactory.Builders[BSN.Config.Driver.Browser].Invoke().GetRemoteDriver(BSN.Config.Driver.Host);

            FinishSetup();
        }

        public static void Init(Func<IDriverBuilder> builder)
        {
            _driver = BSN.Config.Driver.Host == null
                ? builder.Invoke().GetDriver
                : builder.Invoke().GetRemoteDriver(BSN.Config.Driver.Host);

            FinishSetup();
        }

        public static void Init(IWebDriver driver)
        {
            _driver = driver;
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

        private static void FinishSetup()
        {
            Wait = new Wait(BSN.Config.Driver.Timeout);
            Window = new Window();
            Window.Maximize();
        }
    }
}