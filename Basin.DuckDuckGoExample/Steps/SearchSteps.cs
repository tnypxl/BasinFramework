using System.Collections.Generic;
using Basin.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basin.DuckDuckGoExample.Steps
{
    [Binding]
    public class SearchSteps : StepsBase
    {
        private static string _query;

        [Given(@"I want to know the definition of the word ""(\w+)""")]
        public void GivenIWantToKnowTheDefinitionOfAWord(string word)
        {
            _query = $"define {word}";
        }

        [StepDefinition(@"I am on the home page")]
        public static void GivenIAmOnTheHomePage()
        {
            Driver.Goto(Config.GetSite(Config.CurrentSite).Url);
        }

        [StepDefinition(@"I perform a search")]
        public static void WhenIPerformASearchFor()
        {
            Pages.Home.PerformSearch(_query);
        }
        
        [Then(@"I should see the word ""(?:.*)"" defined as")]
        [Then(@"I should see the following definition")]
        public static void ThenISeeRelevantResultsFor(string definition)
        {
            Assert.That(Pages.Results.WordDefinitionDisplayed(definition));
        }


    }
}
