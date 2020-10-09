using Basin.PageObjects;
using Basin.Selenium;
using Google.Protobuf.Collections;

namespace Basin.Tests.PageObjects
{
    public class HomePage : Page
    {
        public HomePage()
        {
            BuildExamples();
        }

        private Element ExampleLink(string name) => AnchorTag.WithText(name).Inside(ListItemTag);

        public void NavigateToExample(string name) => I.Click(ExampleLink(name));

        public PageCollection Examples { get; } = new PageCollection();

        public void BuildExamples()
        {
            Examples.Add(new AddRemoveElementsExamplePage());
            Examples.Add(new LargeAndDeepDomExamplePage());
        }
    }
}
