using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Basin.PageObjects
{
    public class PageActor : PageMap, IPageActor
    {
        [ThreadStatic] private static IJavaScriptExecutor _javascript;

        public PageActor()
        {
            _javascript = (IJavaScriptExecutor)BrowserSession.Current;
        }

        public Actions Actions => new Actions(BrowserSession.Current);

        public virtual void Click(Element element) => element.Click();

        public virtual void EnterText(string text, Element element) => element.SendKeys(text);

        public virtual void WaitForElement(Element element)
        {
            Wait.Until(_ => element.Displayed);
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
            return _javascript.ExecuteScript(script);
        }

        public virtual object ExecuteScript(string script, params object[] args)
        {
            return _javascript.ExecuteScript(script, ProcessScriptArgs(args));
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

        private static IList<object> ProcessScriptArgs(params object[] args)
        {
            var newArgs = args;

            for (var i = 0; i < newArgs.Length; i++)
            {

                if (newArgs[i].GetType() is Element)
                    newArgs[i] = (IWebElement) args[i];
            }

            return newArgs;
        }
    }
}
