using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Basin.Selenium
{
    public class Element : IWebElement
    {
        private readonly IWebElement _element;
        private readonly IWebElement _parentElement;

        private static DefaultWait<IWebDriver> _wait(int timeout)
        {
            var wait = new DefaultWait<IWebDriver>(Driver.Current)
            {
                Timeout = TimeSpan.FromSeconds(timeout)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            return wait;
        }

        public Element(IWebElement element)
        {
            _element = element;
        }

        public Element(By by)
        {
            FoundBy = by;
        }

        public Element(By by, By parentBy)
        {
            FoundBy = by;
            ParentFoundBy = parentBy;
            _parentElement = new Element(parentBy);

        }

        public bool Exists
        {
            get
            {
                try
                {
                    return _wait(2).Until(d => d.FindElement(FoundBy).Displayed);
                }
                catch (WebDriverTimeoutException)
                {
                    return false;
                }
            }
        }

        public By FoundBy { get; set; }

        public By ParentFoundBy { get; set; }

        /// <summary>
        /// Locates and returns an <see cref="IWebElement"/>, will return null if its
        /// </summary>
        private IWebElement Locate
        {
            get
            {
                return _wait(2).Until(driver =>
                {
                    var element = _parentElement != null
                        ? _parentElement.FindElement(FoundBy)
                        : driver.FindElement(FoundBy);

                    return element.Displayed ? element : null;
                });
            }
        }


        //private IWebElement Current => _element ?? throw new NullReferenceException("_element is null.");

        private IWebElement Current => Locate ?? throw new NullReferenceException("Element could not located because it was null");

        private IWebElement CurrentParent => _parentElement ?? throw new NullReferenceException("Parent element could not be located because it was null");

        public Func<IWebDriver, bool> IsDisplaying => WaitConditions.ElementDisplayed(_element);

        public Func<IWebDriver, bool> IsNotDisplaying => WaitConditions.ElementNotDisplayed(_element);

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            Current.Click();
        }

        public IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Current.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return Current.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            Current.SendKeys(text);
        }

        public void Submit()
        {
            Current.Submit();
        }

        public void Hover()
        {
            var actions = new Actions(Driver.Current);
            actions.MoveToElement(Current).Perform();
        }
    }
}