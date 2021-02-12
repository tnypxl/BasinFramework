using System;
using System.Text.RegularExpressions;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Basin.PageObjects
{
    public class PageActor : PageMap, IPageActor
    {
        public Actions Actions => new Actions(BrowserSession.Current);

        public virtual void Click(Element element) => element.Click();

        public virtual void EnterText(string text, Element element) => element.SendKeys(text);

        public virtual void WaitForElement(Element element)
        {
            Wait.Until(_ => element.Displayed);
        }

        public virtual void WaitForElement(Element element, int numberOfSeconds)
        {
            Wait.Until(_ => element.Displayed, numberOfSeconds);
        }

        public virtual void WaitForNumberOfElements(int numberOfElements, Element element)
        {
            Wait.Until(_ => element.All.Count >= 1 && element.All.Count == numberOfElements);
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

        public virtual bool SeeNumberOfElements(int numberOfElements, Element element)
        {
            var actualNumberOfElements = GetNumberOfElements(element);

            return actualNumberOfElements == numberOfElements;
        }

        public virtual bool SeeText(string text)
        {
            // var bodyWithText = BodyTag.WithText(text);

            return BodyTag.Text.Contains(text);
        }

        public virtual bool SeeText(string text, Element element)
        {
            return element.Text.Contains(text);
        }

        public virtual void PressKey(params string[] keys)
        {
            Actions.SendKeys(string.Join(string.Empty, keys)).Perform();
        }

        public virtual void CheckOption(Element element)
        {
            IsCheckableInput(element);

            if (!string.IsNullOrEmpty(element.GetAttribute("checked"))) return;

            element.Click();
        }

        public virtual void UncheckOption(Element element)
        {
            IsCheckableInput(element);

            if (string.IsNullOrEmpty(element.GetAttribute("checked"))) return;

            element.Click();
        }

        public virtual void SelectOptionByText(string optionText, Element selectList)
        {
            IsSelectList(selectList);
            Click(selectList);
            Click(OptionTag.WithText(optionText).Inside(selectList));
        }

        public virtual void SelectOptionByValue(string optionValue, Element selectList)
        {
            IsSelectList(selectList);
            Click(selectList);
            Click(OptionTag.WithAttr("value", optionValue).Inside(selectList));
        }

        public virtual object ExecuteScript(string script)
        {
            var javascript = (IJavaScriptExecutor) BrowserSession.Current;
            var result = javascript.ExecuteScript(script);

            return result;
        }

        public virtual object ExecuteScript(string script, params object[] args)
        {
            var javascript = (IJavaScriptExecutor) BrowserSession.Current;
            var newArgs = ProcessScriptArgs(args);
            var result = javascript.ExecuteScript(script, newArgs);

            return result;
        }

        public virtual Wait Wait => BrowserSession.Wait;

        private static void IsSelectList(IWebElement selectList)
        {
            if (selectList.TagName == "select") return;

            throw new ArgumentException("Element is not a select list input.");
        }

        private static void IsCheckableInput(IWebElement element)
        {
            if (element.TagName == "input"
                && Regex.IsMatch(element.GetAttribute("type"), "checkbox|radio")
                && element.Enabled) return;

            throw new ArgumentException("Element is not a checkbox or radio input or is disabled");
        }

        private static object[] ProcessScriptArgs(params object[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (!(args[i] is Element)) continue;

                var element = (Element) args[i];
                args[i] = BrowserSession.Current.FindElement(element.GetLocator().By);
            }

            return args;
        }
    }
}
