using Basin.Pages;
using Basin.Selenium;

namespace Basin.Tests.Pages
{
    public class LargeAndDeepDOMExamplePage : Page
    {
        private Element Item(string text) => DivTag.WithText(text);

        public bool ItemComesAfter(string itemText, string followingItemText)
        {
            return Item(itemText).After(Item(followingItemText)).Exists;
        }

        public bool ItemComesBefore(string itemText, string precedingItemText)
        {
            return Item(itemText).Before(Item(precedingItemText)).Exists;
        }
    }
}