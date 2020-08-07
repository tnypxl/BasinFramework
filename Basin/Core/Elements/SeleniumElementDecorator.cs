using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Basin.Core.Elements
{
    public class SeleniumElementDecorator : ElementDecorator, IWebElement
    {
        public SeleniumElementDecorator(Element element) : base(element)
        {
        }

        private IWebElement Current => FoundElement ?? throw new NullReferenceException("Element could not be located because it was null");

        protected DefaultWait<IWebDriver> Wait { get; } = BrowserSession.ElementWait;

        private IWebElement FoundElement
        {
            get
            {
                return Wait.Until(driver =>
                {
                    var element = driver.FindElement(Locator.By);

                    return element.Displayed ?
                        element :
                        null;
                });
            }
        }

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

        public void Clear() => Current.Clear();

        public void Click() => Current.Click();

        public IWebElement FindElement(By by) => Current.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => Current.FindElements(by);

        public string GetAttribute(string attributeName) => Current.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => Current.GetCssValue(propertyName);

        public string GetProperty(string propertyName) => Current.GetProperty(propertyName);

        public void SendKeys(string text) => Current.SendKeys(text);

        public void Submit() => Current.Submit();

        public void Hover()
        {
            var actions = new Actions(BrowserSession.Current);

            actions.MoveToElement(Current).Perform();
        }
    }
}
