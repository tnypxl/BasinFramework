using Basin.Pages;
using Basin.Selenium;

namespace Basin.Tests.Pages
{
    public class LargeAndDeepDOMExamplePage : Page
    {
        public Element Item(string text) => DivTag.WithId($"sibling-{text}");
    }
}