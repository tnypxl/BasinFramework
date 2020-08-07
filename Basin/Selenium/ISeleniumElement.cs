using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Basin.Selenium
{
    public interface ISeleniumElement
    {
        Elements All { get; }
        string Description { get; set; }
        bool Displayed { get; }
        bool Enabled { get; }
        bool Exists { get; }
        By FoundBy { get; set; }
        Func<IWebDriver, bool> IsDisplaying { get; }
        Func<IWebDriver, bool> IsNotDisplaying { get; }
        Point Location { get; }
        bool Selected { get; }
        Size Size { get; }
        string TagName { get; }
        string Text { get; }

        Element As(string description);
        Element Child();
        Element Child(Element element);
        void Clear();
        void Click();
        IWebElement FindElement(By by);
        ReadOnlyCollection<IWebElement> FindElements(By by);
        Element Follows(Element element);
        string GetAttribute(string attributeName);
        string GetCssValue(string propertyName);
        string GetProperty(string propertyName);
        void Hover();
        Element IfTextMatches(string pattern);
        Element Inside(Element parent);
        Element Parent();
        Element Parent(Element element);
        Element Precedes(Element element);
        void SendKeys(string text);
        void Submit();
        Element WithAttr(string name, bool inclusive = true);
        Element WithAttr(string name, string value, bool inclusive = true);
        Element WithChild(Element child, bool inclusive = true);
        Element WithClass(string className, bool inclusive = true);
        Element WithDescendant(Element descendant, bool inclusive = true);
        Element WithId(string id, bool inclusive = true);
        Element WithText(string text, bool inclusive = true);
    }
}