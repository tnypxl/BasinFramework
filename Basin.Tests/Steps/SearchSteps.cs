using Basin;
using Basin.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public class SearchSteps
    {
        private static string _query;

        [Given("I am on the home page")]
        public static void OnTheHomePage()
        {
            Driver.Goto(BSN.Config.Site.Url);
        }

        [StepDefinition(@"I want to know the definition of the word ""(\w+)""")]
        public void WantToKnowTheDefinitionOfAWord(string word)
        {
            _query = $"define {word}";
        }

        [When("I perform a search")]
        public static void PerformASearchFor()
        {
            Pages.Home.PerformSearch(_query);
        }

        [Then(@"I should see the word ""(?:.*)"" defined as")]
        [Then("I should see the following definition")]
        public static void ShouldSeeRelevantResultsFor(string definition)
        {
            Assert.That(Pages.Results.WordDefinitionDisplayed(definition));
        }
    }
}
