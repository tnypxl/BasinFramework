using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class LargeAndDeepDOMExamplePage : Page
    {
        public Element Item(string text) => DivTag.WithId($"sibling-{text}");

        public Element ItemWithExactText(string text) => DivTag.WithText(text);

        public Element ItemContainingText(string text) => DivTag.WithText($"*|{text}");
    }
}