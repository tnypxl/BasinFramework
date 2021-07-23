using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.Selenium.PageObjects
{
    public class HomePage : Page
    {
        public HomePage()
        {
            BuildExamples();
        }

        private Element ExampleLink(string name) => AnchorTag.WithText(name).Inside(ListItemTag);

        public void NavigateToExample(string name) => ExampleLink(name).Click();

        public PageCollection Examples { get; } = new PageCollection();

        public void BuildExamples()
        {
            Examples.Add(new AddRemoveElementsExamplePage());
            Examples.Add(new LargeAndDeepDomExamplePage());
        }
    }
}
