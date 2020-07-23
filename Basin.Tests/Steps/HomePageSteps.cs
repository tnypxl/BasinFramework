using Basin.PageObjects;
using Basin.Selenium;
using Basin.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public class HomePageSteps
    {
        [Given("I am on the home page")]
        public void OnTheHomePage()
        {
            BrowserSession.Goto(BasinEnv.Site.Url);
        }

        [StepDefinition("I navigate to the example named '(.*?)'")]
        public void NavigateToExample(string exampleName)
        {
            Pages.Use<HomePage>(p => p.NavigateToExample(exampleName));
        }
    }
}
