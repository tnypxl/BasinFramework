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

        public static Element Locate(By by)
        {
            var element = Wait.Until(driver => driver.FindElement(by));
            return new Element(element)
            {
                FoundBy = by
            };
        }

        public static Element Locate(string selector)
        {
            var locator = new Locator(selector).By;

            return Locate(locator);
        }

        public static Element LocateInside(By by, By parentBy)
        {
            var parentElement = Locate(parentBy);
            var element = Wait.Until(driver => parentElement.FindElement(by));

            return new Element(element)
            {
                FoundBy = by,
                ParentFoundBy = parentBy
            };
        }

        public static Element LocateInside(string selector, string parentSelector)
        {
            var locator = new Locator(selector).By;
            var parentLocator = new Locator(parentSelector).By;

            return LocateInside(locator, parentLocator);
        }

        public static Elements LocateAll(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        public static Elements LocateAll(string selector)
        {
            return LocateAll(new Locator(selector).By);
        }

        public static Elements LocateAllInside(By by, By parentBy)
        {
            var parentElement = Locate(parentBy);
            var elements = new Elements(parentElement.FindElements(by))
            {
                FoundBy = by,
                ParentFoundBy = parentBy
            };

            return Wait.Until(WaitConditions.ElementsNotEmpty(elements));
        }

        public static Elements LocateAllInside(string selector, string parentSelector)
        {
            return LocateAllInside(
                new Locator(selector).By,
                new Locator(parentSelector).By);
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