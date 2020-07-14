using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Basin.Tests.Pages;
using System;

namespace Basin.Tests.Steps
{
    [Binding]
    public class LargeAndDeepDomExampleSteps
    {
        private readonly LargeAndDeepDOMExamplePage Page = Pages.LargeAndDeepDOMExample;

        [Then("I can locate element '(.*?)' that follows element '(.*?)'")]
        public void ThenICanLocateElementThatFollowsElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Follows(Page.Item(siblingElementText)).Exists);
        }

        [Then("I can locate element '(.*?)' that precedes element '(.*?)'")]
        public void ThenILocateElementThatPrecedesElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Precedes(Page.Item(siblingElementText)).Exists);
        }

        [Then("I can locate parent (.*?) of element (.*?)")]
        public void ThenICanLocateParentOfElement(string parentText, string elementText)
        {
            Console.WriteLine(Page.Item(elementText).Parent(Page.Item(parentText)).FoundBy.ToString());
            Assert.That(Page.Item(elementText).Parent(Page.Item(parentText)).Exists);
        }

        [Then("I can locate the first parent of element (.*?)")]
        public void ThenICanLocateParentOfElement(string elementText)
        {
            Console.WriteLine(Page.Item(elementText).Parent().FoundBy.ToString());
            Assert.That(Page.Item(elementText).Parent().Exists);
        }
    }
}