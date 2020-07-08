using Basin.Selenium;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public static class HomePageSteps
    {
        [Given("I am on the home page")]
        public static void OnTheHomePage()
        {
            Browser.Goto(Basin.Config.Site.Url);
        }

        [Given(@"I navigate to the example named '(.*?)'")]
        public static void NavigateToExample(string exampleName)
        {
            Pages.Home.NavigateToExample(exampleName);
        }
    }
}
