using NUnit.Framework;
using TechTalk.SpecFlow;
using Basin.Tests.PageObjects;
using Basin.PageObjects;
using System;

namespace Basin.Tests.Steps
{
    [Binding]
    public class LargeAndDeepDomExampleSteps
    {
        private LargeAndDeepDOMExamplePage Page => Pages.Get<LargeAndDeepDOMExamplePage>();

        [Then("I can locate element '(.*?)' that follows element '(.*?)'")]
        public void ThenICanLocateElementThatFollowsElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Follows(Page.Item(siblingElementText)).Exists);
        }

        [Then("I can locate element '(.*?)' that precedes element '(.*?)'")]
        public void ThenICanLocateElementThatPrecedesElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Precedes(Page.Item(siblingElementText)).Exists);
        }

        [Then("I can locate the first parent of element")]
        public void ThenICanLocateParentOfElement()
        {
            const string elementText = "4.1";

            Assert.That(Page.Item(elementText).Parent().Exists);
            Assert.That(Page.Item(elementText).Parent().WithId("sibling-3.1").Exists);
        }

        [Then("I can locate parent '(.*?)' of element '(.*?)'")]
        public void ThenICanLocateSpecificParentOfElement(string parentText, string elementText)
        {
            Assert.That(Page.Item(elementText).Parent(Page.Item(parentText)).Exists);
        }

        [Then("I can locate the first child of element")]
        public void ThenICanLocateChildOfElement()
        {
            const string elementText = "4.1";

            Assert.That(Page.Item(elementText).Child(Page.Item("4.2")).Exists);
        }

        [Then("I can locate child '(.*?)' of element '(.*?)'")]
        public void ThenICanLocateSpecificChildOfElement(string childText, string elementText)
        {
            Assert.That(Page.Item(elementText).Child(Page.Item(childText)).Exists);
        }
    }
}