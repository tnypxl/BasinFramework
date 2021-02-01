using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class DynamicLoadingExamplePage : Page
    {
        public Element ExampleOneLink => AnchorTag.WithText("Example 1: Element on page that is hidden");

        public Element ExampleTwoLink => AnchorTag.WithText("Example 2: Element rendered after the fact");

        public Element StartButton => ButtonTag.WithText("Start").Inside(DivTag.WithId("start"));

        public Element FinishText => DivTag.WithId("finish").WithText("Hello World!");
    }
}
