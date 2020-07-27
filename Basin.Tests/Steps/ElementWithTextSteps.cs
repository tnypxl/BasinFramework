using System.Runtime.Serialization;
using Basin.PageObjects;
using Basin.Tests.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basin.Tests.Steps
{
    [Binding]
    public class ElementWithTextSteps
    {
        public DynamicControlsExamplePage DynamicControlsExample => Pages.Get<DynamicControlsExamplePage>();

        [When("I remove the checkbox")]
        public void WhenIAddAnElementToThePage()
        {
            DynamicControlsExample.RemoveCheckbox();
        }

        [Then("I can locate a message that contains text '(.*?)'")]
        public void ThenICanLocateAMessageThatContainsText(string text)
        {
            Assert.That(DynamicControlsExample.Map.Message($"*|{text}").Exists, Is.True);
        }

        [Then("I can locate a message with exact text '(.*?)'")]
        public void ThenICanLocateAMessageWithExactText(string text)
        {
            Assert.That(DynamicControlsExample.Map.Message(text).Exists, Is.True);
        }

        [Then("I can locate a message that ends with text '(.*?)'")]
        public void ThenICanLocateAMessageThatEndsWithText(string text)
        {
            Assert.That(DynamicControlsExample.Map.Message($"$|{text}").Exists, Is.True);
        }

        [Then("I can locate a message that starts with text '(.*?)'")]
        public void ThenICanLocateAMessageThatStartsWithText(string text)
        {
            Assert.That(DynamicControlsExample.Map.Message($"^|{text}").Exists, Is.True);
        }
    }
}