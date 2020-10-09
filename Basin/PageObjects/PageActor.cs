using System;
using System.Collections.ObjectModel;
using System.Linq;
using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Basin.PageObjects
{
    public class PageActor
    {
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
            var action = new Actions(BrowserSession.Current);
            
            action.SendKeys(string.Join(string.Empty, keys)).Perform();
        }

        public virtual string GetAttributeFrom(Element element, string attributeName) => element.GetAttribute(attributeName);

        public virtual string[] GetAttributeFromAll(Element element, string attributeName)
        {
            var numberOfElements = GetNumberOfElements(element);
            if (numberOfElements > 1)
                
        }

        public virtual Wait Wait => BrowserSession.Wait;
        
    }
}