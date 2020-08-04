using System;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public interface IElement
    {
        string Description { get; set; }
        By FoundBy { get; set; }
        Func<IWebDriver, bool> IsDisplaying { get; }
        Func<IWebDriver, bool> IsNotDisplaying { get; }
        Elements All { get; }
        Element As(string description);
        Element Child();
        Element Child(Element element);
        Element Follows(Element element);
        Element IfTextMatches(string pattern);
        Element Inside(Element parent);
        Element Parent();
        Element Parent(Element element);
        Element Precedes(Element element);
        Element WithAttr(string name, bool inclusive = true);
        Element WithAttr(string name, string value, bool inclusive = true);
        Element WithChild(Element child, bool inclusive = true);
        Element WithClass(string className, bool inclusive = true);
        Element WithDescendant(Element descendant, bool inclusive = true);
        Element WithId(string id, bool inclusive = true);
        Element WithText(string text, bool inclusive = true);
    }
}