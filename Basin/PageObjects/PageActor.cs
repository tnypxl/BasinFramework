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

        public bool SeeText(string text)
        {
            // var bodyWithText = BodyTag.WithText(text);

            return BodyTag.Text.Contains(text);
        }

        public bool SeeText(string text, Element element)
        {
            return element.Text.Contains(text);
        }

        public virtual void PressKey(params string[] keys)
        {
            Actions.SendKeys(string.Join(string.Empty, keys)).Perform();
        }

        public virtual void CheckOption(Element element)
        {
            IsCheckboxOrRadio(element);

            if (!string.IsNullOrEmpty(element.GetAttribute("checked"))) return;

            element.Click();
        }

        public virtual void UncheckOption(Element element)
        {
            IsCheckboxOrRadio(element);

            if (string.IsNullOrEmpty(element.GetAttribute("checked"))) return;

            element.Click();
        }

        public virtual void SelectOption(string optionValue, Element selectList)
        {
            IsSelectList(selectList);

            var optionByText = OptionTag.WithText(optionValue).Inside(selectList);
            var optionByValue = OptionTag.WithAttr("value", optionValue).Inside(selectList);

            Click(selectList);

            if (optionByText.Displayed) Click(optionByText);
            if (optionByValue.Displayed) Click(optionByValue);

            throw new ArgumentException($"Option with text or value '{optionValue}' could not be located");
        }


        public virtual object ExecuteScript(string script)
        {
            return _javascript.ExecuteScript(script);
        }

        public virtual object ExecuteScript(string script, params object[] args)
        {
            return _javascript.ExecuteScript(script, args);
        }

        public virtual Wait Wait => BrowserSession.Wait;

        private static void IsSelectList(IWebElement selectList)
        {
            if (selectList.TagName == "select") return;

            throw new ArgumentException("Element is not a select list input.");
        }

        private static void IsCheckboxOrRadio(IWebElement element)
        {
            if (element.TagName == "input"
                && Regex.IsMatch(element.GetAttribute("type"), "checkbox|radio")
                && element.Enabled) return;

            throw new ArgumentException("Element is not a checkbox or radio input");
        }

    }
}
