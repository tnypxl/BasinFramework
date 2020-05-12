using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool Condition(IWebDriver driver)
            {
                return element.Displayed;
            }

            return Condition;
        }

        public static Func<IWebDriver, IWebElement> ElementIsDisplayed(IWebElement element)
        {
            IWebElement Condition(IWebDriver driver)
            {
                try
                {
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
            }

            return Condition;
        }

        public static Func<IWebDriver, bool> ElementNotDisplayed(IWebElement element)
        {
            bool Condition(IWebDriver driver)
            {
                try
                {
                    return !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            }

            return Condition;
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> ElementsNotEmpty(Elements elements)
        {
            ReadOnlyCollection<IWebElement> Condition(IWebDriver driver)
            {
                var foundElements = driver.FindElements(elements.FoundBy);
                return foundElements.Count == 0 ? null : foundElements;
            }

            return Condition;
        }
    }
}