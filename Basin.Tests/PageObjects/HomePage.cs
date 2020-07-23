using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class HomePage : Page
    {
        private Element ExampleLink(string name) => AnchorTag.WithText(name).Inside(ListItemTag);

        public void NavigateToExample(string name) => ExampleLink(name).Click();
    }
}
