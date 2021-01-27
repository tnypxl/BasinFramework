using System;
using System.Text.RegularExpressions;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Basin.PageObjects
{
    public class PageActor : IPageActor
    {
        private static IJavaScriptExecutor Javascript => (IJavaScriptExecutor)BrowserSession.Current;

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

        public virtual bool WaitForNumberOfElements(Element element, int numberOfElements)
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

        public bool SeeText(string text)
        {
            throw new NotImplementedException();
        }

        public bool SeeText(string text, Element element)
        {
            throw new NotImplementedException();
        }

        public virtual void PressKey(params string[] keys)
        {

            Actions.SendKeys(string.Join(string.Empty, keys)).Perform();
        }

        public virtual void CheckOption(Element element)
        {
            if (!IsCheckable(element) && string.IsNullOrEmpty(element.GetAttribute("checked"))) return;

            element.Click();
        }

        public void UncheckOption(Element element)
        {
            throw new NotImplementedException();
        }

        public void SelectOption(Element element, string value)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScript(string script)
        {
            return Javascript.ExecuteScript(script);
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return Javascript.ExecuteScript(script, args);
        }

        public virtual Wait Wait => BrowserSession.Wait;

        private static bool IsCheckable(Element element)
        {
            return element.TagName == "input"
                   && Regex.IsMatch(element.GetAttribute("type"), "checkbox|radio")
                   && element.Enabled;
        }

    }
}
