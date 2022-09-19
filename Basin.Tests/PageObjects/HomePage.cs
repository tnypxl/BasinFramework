using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class HomePage : Page
    {
        public HomePage()
        {
            BuildExamplePages();
        }

        private Element LinkToExamplePage(string name) => AnchorTag.WithText(name).Inside(ListItemTag);

        private PageCollection ExamplePages { get; } = new();

        private void BuildExamplePages()
        {
            ExamplePages.Add(new AddRemoveElementsExamplePage());
            ExamplePages.Add(new LargeAndDeepDomExamplePage());
        }

        public void NavigateToExample(string name) => LinkToExamplePage(name).Click();
    }
}
