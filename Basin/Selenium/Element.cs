using System.Text.RegularExpressions;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using Basin.Core.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Basin.Selenium
{
    public class Element : IWebElement, IElement, IShadowElement
    {
        #region Private Fields

        private readonly int _timeout;

        private readonly DefaultWait<IWebDriver> _wait;

        private readonly ILocatorBuilder _locator;

        #endregion

        #region Constructors

        public Element()
        {
            _wait = new DefaultWait<IWebDriver>(BrowserSession.Current);
            _timeout = BasinEnv.Browser.ElementTimeout;
        }

        public Element(By by)
        {
            FoundBy = by;
            _wait = new DefaultWait<IWebDriver>(BrowserSession.Current);
            _timeout = BasinEnv.Browser.ElementTimeout;
        }

        public Element(string tagName)
        {
            _wait = new DefaultWait<IWebDriver>(BrowserSession.Current);
            _locator = new Locator(tagName);
            _timeout = BasinEnv.Browser.ElementTimeout;
        }

        #endregion

        #region Private Props
        
        private static IJavaScriptExecutor Js => (IJavaScriptExecutor) BrowserSession.Current;

        private DefaultWait<IWebDriver> Wait
        {
            get
            {
                _wait.Timeout = TimeSpan.FromSeconds(_timeout);
                _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                return _wait;
            }
        }

        private IWebElement Locate
        {
            get
            {
                FoundBy ??= _locator.By;
                return FoundElement;
            }
        }

        private IWebElement FoundElement => Wait.Until(driver =>
        {
            var element = driver.FindElement(FoundBy);

            return element.Displayed ? element : null;
        });

        

        private IWebElement Current => Locate ?? throw new NullReferenceException("Element could not be located because it was null");
        
        #endregion

        #region Public Props

        public string Label { get; set; }
        
        [Obsolete("Use `Element.Displayed` instead!")]
        public bool Exists => Displayed;
        public By FoundBy { get; set; }

        public Func<IWebDriver, bool> IsDisplaying => WaitConditions.ElementDisplayed(Current);

        public Func<IWebDriver, bool> IsNotDisplaying => WaitConditions.ElementNotDisplayed(Current);

        #endregion
        
        #region Public IWebElement Props

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed
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

        #endregion

        #region Public IWebElement Methods

        public void Clear() => Current.Clear();

        public void Click() => Current.Click();

        public IWebElement FindElement(By by) => Current.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => Current.FindElements(by);

        public string GetAttribute(string attributeName) => Current.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => Current.GetCssValue(propertyName);

        public string GetProperty(string propertyName) => Current.GetProperty(propertyName);

        public void SendKeys(string text) => Current.SendKeys(text);

        public void Submit() => Current.Submit();

        #endregion
        
        #region Public Locator Methods

        public Element Inside(Element parentElement)
        {
            _locator.Inside(parentElement._locator);

            return this;
        }

        public Element WithText(string text, bool inclusive = true)
        {
            _locator.WithText(text, inclusive);

            return this;
        }

        public Element WithClass(string className, bool inclusive = true)
        {
            _locator.WithClass(className, inclusive);

            return this;
        }

        public Element WithClass(params string[] classNames)
        {
            _locator.WithClass(classNames);

            return this;
        }

        public Element WithId(string id, bool inclusive = true)
        {
            _locator.WithId(id, inclusive);

            return this;
        }

        public Element WithAttr(string name, bool inclusive = true)
        {
            _locator.WithAttr(name, inclusive);

            return this;
        }

        public Element WithAttr(string name, string value, bool inclusive = true)
        {
            _locator.WithAttr(name, value, inclusive);

            return this;
        }

        public Element WithChild(Element childElement, bool inclusive = true)
        {
            _locator.WithChild(childElement._locator, inclusive);

            return this;
        }

        public Element WithDescendant(Element descendantElement, bool inclusive = true)
        {
            _locator.WithDescendant(descendantElement._locator, inclusive);

            return this;
        }

        public Element Parent()
        {
            _locator.Parent();

            return this;
        }

        public Element Parent(Element parentElement)
        {
            _locator.Parent(parentElement._locator);

            return this;
        }

        public Element Child()
        {
            _locator.Child();

            return this;
        }

        public Element Child(Element childElement)
        {
            _locator.Child(childElement._locator);

            return this;
        }

        public Element Precedes(Element siblingElement)
        {
            _locator.Precedes(siblingElement._locator);

            return this;
        }

        public Element Follows(Element siblingElement)
        {
            _locator.Follows(siblingElement._locator);

            return this;
        }

        public Element As(string label)
        {
            Label = label;

            return this;
        }

        public Element AtPosition(int position)
        {
            _locator.AtPosition(position);

            return this;
        }

        public Element Shadow => (Element) Js.ExecuteScript("return arguments[0].shadowRoot", this);
        
        #endregion
        
        #region Public Misc. Methods

        public void Hover()
        {
            var actions = new Actions(BrowserSession.Current);

            actions.MoveToElement(Current).Perform();
        }
        
        public Element IfTextMatches(string pattern)
        {
            if (!Displayed)
                throw new NoSuchElementException("Could not match element text because element was not visible.");

            if (!Regex.IsMatch(Text, pattern))
                throw new ArgumentException("Element's text did not match the pattern provided.");

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

        #endregion
    }
}