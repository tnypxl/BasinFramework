using System;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool Condition(IWebDriver driver) => element.Displayed;

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

        public static Func<IWebDriver, Elements> ElementsNotEmpty(Elements elements)
        {
            Elements Condition(IWebDriver driver)
            {
                Elements foundElements = Driver.LocateAll(elements.FoundBy);
                return foundElements.IsEmpty ? null : foundElements;
            }

            return Condition;
        }
    }
}