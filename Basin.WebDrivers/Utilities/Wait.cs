using System.Collections.ObjectModel;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Basin.WebDrivers.Utilities
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int waitSeconds)
        {
            _wait = new WebDriverWait(DriverSession.Current, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException),
                typeof(WebDriverTimeoutException)
            );
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public IWebElement Until(Func<IWebDriver, IWebElement> condition)
        {
            return _wait.Until(condition);
        }

        public ReadOnlyCollection<IWebElement> Until(Func<IWebDriver, ReadOnlyCollection<IWebElement>> condition)
        {
            return _wait.Until(condition);
        }
    }
}