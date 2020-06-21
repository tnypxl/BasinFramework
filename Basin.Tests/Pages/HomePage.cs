using Basin.Tests.Pages.Shared;
using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.Pages
{
    public class HomePage : Page
    {
        private Element ExampleLink(string name) => AnchorTag.WithText(name).Inside(ListItemTag);

        public void NavigateToExample(string name) => ExampleLink(name).Click();
    }
}
