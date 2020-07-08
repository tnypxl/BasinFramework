using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public static class AddRemoveElementsSteps
    {
        [When("I add an element to the page")]
        public static void WhenIAddAnElementToThePage()
        {
            Pages.AddRemoveElementsExample.AddElement();
        }

        [Then(@"I can see (\d+) Delete buttons? has been added")]
        public static void ThenICanSeeASingleElementHasBeenAdded(int expectedCount)
        {
            Assert.That(
                Pages.AddRemoveElementsExample.HasNumberOfDeleteButtons(expectedCount),
                $"Expected {expectedCount} Delete button(s) to be displayed. Got {Pages.AddRemoveElementsExample.Map.AllDeleteButtons.Count} instead.");
        }
    }
}