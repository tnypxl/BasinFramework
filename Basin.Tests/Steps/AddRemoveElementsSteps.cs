using Basin.PageObjects;
using Basin.Tests.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public class AddRemoveElementsSteps
    {
        public AddRemoveElementsExamplePage Page => Pages.Get<AddRemoveElementsExamplePage>();

        [When("I add an element to the page")]
        public void WhenIAddAnElementToThePage()
        {
            Page.AddElement();
        }

        [Then(@"I can see (\d+) Delete buttons? has been added")]
        public void ThenICanSeeASingleElementHasBeenAdded(int expectedCount)
        {
            Assert.That(
                Page.HasNumberOfDeleteButtons(expectedCount),
                $"Expected {expectedCount} Delete button(s) to be displayed. Got {Page.Map.AllDeleteButtons.Count} instead.");
        }
    }
}