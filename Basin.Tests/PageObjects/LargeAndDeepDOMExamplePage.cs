using Basin.PageObjects;
using Basin.Selenium;
using System;

namespace Basin.Tests.PageObjects
{
    public class LargeAndDeepDOMExamplePage : Page
    {
        public Element Item(string text) => DivTag.WithId($"sibling-{text}");

        public Element ItemWithExactText(string text) => DivTag.WithText(text);

        public Element ItemContainingText(string text) => DivTag.WithText($"*|{text}");

        public Element ItemWithoutClassName(string text, string className) => Item(text).WithClass(className, false);

        public Element ItemWithoutDescedant(string elementText, string descendantText) => Item(elementText).WithDescendant(Item(descendantText), false);
    }
}