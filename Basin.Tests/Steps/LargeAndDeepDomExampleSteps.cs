using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Basin.Tests.Pages;

namespace Basin.Tests.Steps
{
    [Binding]
    public class LargeAndDeepDomExampleSteps
    {
        private readonly LargeAndDeepDOMExamplePage Page = Pages.LargeAndDeepDOMExample;

        [Then("I can locate element '(.*?)' by its following element '(.*?)'")]
        public void ThenILocateFindElementByItsFollowingElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Follows(Page.Item(siblingElementText)).Displayed);
        }

        [Then("I can locate element '(.*?)' by its preceding element '(.*?)'")]
        public void ThenILocateFindElementByItsPrecedingElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Precedes(Page.Item(siblingElementText)).Displayed);
        }

        [Then("I can locate parent (.*?) of element (.*?)")]
        public void ThenICanLocateParentOfElement(string elementText, string parentText)
        {
            Assert.That(Page.Item(elementText).Parent(Page.Item(parentText)).Displayed);
        }
    }
}