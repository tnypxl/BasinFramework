using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Basin.Core.Locators;
using Basin.Core.Locators.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Basin.Selenium
{
    public sealed class Element : IWebElement
    {
        // private readonly IWebElement _element;

        private readonly int _timeout;

        private readonly ILocatorBuilder _locator;

        public Element(string tagName)
        {
            _locator = new Locator(tagName);
            _timeout = BasinEnv.Browser.ElementTimeout;
        }

        public string Description { get; set; }

        public By FoundBy { get; set; }

        public By ParentFoundBy { get; set; }

        private DefaultWait<IWebDriver> Wait
        {
            get
            {
                var wait = new DefaultWait<IWebDriver>(BrowserSession.Current)
                {
                    Timeout = TimeSpan.FromSeconds(_timeout)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                return wait;
            }
        }

        private IWebElement Locate
        {
            get
            {
                FoundBy = _locator.By;

                return Wait.Until(driver =>
                {
                    var element = driver.FindElement(FoundBy);

                    return element.Displayed ?
                        element :
                        null;
                });
            }
        }

        public bool Exists
        {
            get
            {
                try
                {
                    return Current.Displayed;
                }
                catch (WebDriverTimeoutException)
                {
                    return false;
                }
            }
        }

        private IWebElement Current => Locate ??
            throw new NullReferenceException("Element could not be located because it was null");

        public Func<IWebDriver, bool> IsDisplaying => WaitConditions.ElementDisplayed(Current);

        public Func<IWebDriver, bool> IsNotDisplaying => WaitConditions.ElementNotDisplayed(Current);

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
            var actions = new Actions(BrowserSession.Current);

            actions.MoveToElement(Current).Perform();
        }

        public Element Inside(Element parent)
        {
            _locator.Inside(parent._locator);

            return this;
        }

        public Element WithText(string text)
        {
            _locator.WithText(text);

            return this;
        }

        public Element WithClass(string className)
        {
            _locator.WithClass(className);

            return this;
        }

        public Element WithId(string id)
        {
            _locator.WithId(id);

            return this;
        }

        public Element WithAttr(string name)
        {
            _locator.WithAttr(name);

            return this;
        }

        public Element WithAttr(string name, string value)
        {
            _locator.WithAttr(name, value);

            return this;
        }

        public Element WithChild(Element child)
        {
            _locator.WithChild(child._locator);

            return this;
        }

        public Element WithDescendant(Element descendant)
        {
            _locator.WithDescendant(descendant._locator);

            return this;
        }

        public Element Parent()
        {
            _locator.Parent();

            return this;
        }

        public Element Parent(Element element)
        {
            _locator.Parent(element._locator);

            return this;
        }

        public Element Child()
        {
            _locator.Child();

            return this;
        }

        public Element Child(Element element)
        {
            _locator.Child(element._locator);

            return this;
        }

        public Element Precedes(Element element)
        {
            _locator.Precedes(element._locator);

            return this;
        }

        public Element Follows(Element element)
        {
            _locator.Follows(element._locator);

            return this;
        }

        public Element As(string description)
        {
            Description = description;

            return this;
        }

        public Element IfTextMatches(string pattern)
        {
            if (!Exists || !Regex.IsMatch(Current.Text, pattern))
            {
                throw new NoSuchElementException("Element does not exist and/or does contain text matching the pattern provided.");
            }

            return this;
        }

        public Elements All
        {
            get
            {
                var by = _locator != null ? _locator.By : FoundBy;

                return new Elements(BrowserSession.Current?.FindElements(by));
            }
        }
    }
}