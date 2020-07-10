using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public static class LargeAndDeepDomExampleSteps
    {
        [Then("I can see that item '(.*?)' comes after item '(.*?)'")]
        public static void CanSeeItemComesAfterItem(string item, string targetItem)
        {
            Assert.That(Pages.LargeAndDeepDOMExample.ItemComesAfter(item, targetItem));
        }

        [Then("I can see that item '(.*?)' comes before item '(.*?)'")]
        public static void CanSeeItemComesBeforeItem(string item, string targetItem)
        {
            Assert.That(Pages.LargeAndDeepDOMExample.ItemComesBefore(item, targetItem));
        }
    }
}