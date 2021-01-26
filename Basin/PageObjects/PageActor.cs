using System;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Basin.PageObjects
{
    public class PageActor : IPageActor
    {
        public PageActor()
        {
            throw new NotSupportedException();
        }

        public Actions Actions { get; } = new Actions(BrowserSession.Current);

        public virtual void Click(Element element) => element.Click();

        public virtual void EnterText(Element element, string text) => element.SendKeys(text);

        public virtual bool WaitForElement(Element element)
        {
            try
            {
                return Wait.Until(element.IsDisplaying);
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        public virtual bool WaitForNumberOfElements(Element element, int numberOfElements = 2)
        {
            try
            {
                return Wait.Until(_ => element.All.Count > 1 || element.All.Count == numberOfElements);
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        public virtual int GetNumberOfElements(Element element)
        {
            return element.All.Count;
        }

        public virtual bool DontSee(Element element)
        {
            return !element.Displayed;
        }

        public virtual bool See(Element element)
        {
            return element.Displayed;
        }

        public virtual void PressKey(params string[] keys)
        {

            Actions.SendKeys(string.Join(string.Empty, keys)).Perform();
        }

        public virtual Wait Wait => BrowserSession.Wait;

    }
}
