using NUnit.Framework;
using TechTalk.SpecFlow;
using Basin.Tests.PageObjects;
using Basin.PageObjects;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;

namespace Basin.Tests.Steps
{
    [Binding]
    public class LargeAndDeepDomExampleSteps
    {
        private LargeAndDeepDOMExamplePage Page => Pages.Get<LargeAndDeepDOMExamplePage>();

        [Then("I can locate element '(.*?)' that follows element '(.*?)'")]
        public void ThenICanLocateElementThatFollowsElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Follows(Page.Item(siblingElementText)).Displayed);
        }

        [Then("I can locate element '(.*?)' that precedes element '(.*?)'")]
        public void ThenICanLocateElementThatPrecedesElement(string elementText, string siblingElementText)
        {
            Assert.That(Page.Item(elementText).Precedes(Page.Item(siblingElementText)).Displayed);
        }

        [Then("I can locate the first parent of element")]
        public void ThenICanLocateParentOfElement()
        {
            const string elementText = "4.1";

            Assert.That(Page.Item(elementText).Parent().Displayed);
            Assert.That(Page.Item(elementText).Parent().WithId("sibling-3.1").Displayed);
        }

        [Then("I can locate parent '(.*?)' of element '(.*?)'")]
        public void ThenICanLocateSpecificParentOfElement(string parentText, string elementText)
        {
            Assert.That(Page.Item(elementText).Parent(Page.Item(parentText)).Displayed);
        }

        [Then("I can locate the first child of element")]
        public void ThenICanLocateChildOfElement()
        {
            const string elementText = "4.1";

            Assert.That(Page.Item(elementText).Child(Page.Item("4.2")).Displayed);
        }

        [Then("I can locate child '(.*?)' of element '(.*?)'")]
        public void ThenICanLocateSpecificChildOfElement(string childText, string elementText)
        {
            Assert.That(Page.Item(elementText).Child(Page.Item(childText)).Displayed);
        }

        [Then("I can locate an element with exact text '(.*?)'")]
        public void ThenICanLocateAnElementWithExactText(string text)
        {
            Assert.That(Page.ItemWithExactText(text).Displayed, Is.True);
        }

        [Then("I can locate element '(.*?)' excluding class name '(.*?)'")]
        public void ThenICanLocateElementWhichExcludesClassName(string elementText, string className)
        {
            Assert.That(Page.ItemWithoutClassName(elementText, className).Displayed, Is.True);
        }

        [Then("I can locate element '(.*?)' excluding descendant element '(.*?)'")]
        public void ThenICanLocateElementWhichExcludesDescendantElement(string elementText, string descendantText)
        {
            Assert.That(Page.ItemWithoutDescedant(elementText, descendantText).Displayed, Is.True);
        }

        [Then(@"I can locate a table cell in row (\d+) at column (\d+) whose text is '(.*?)'")]
        public void ThenICanLocateATableCellByRowAndColumnWithGivenText(int row, int column, string text)
        {
            Assert.That(Page.TableCellByRowAndColumn(row, column).Text == text, Is.True);
        }

        [Then("I can locate element '(.*?)' whose class attribute includes class name '(.*?)'")]
        public void ThenICanLocateElementWhoseClassAttributeIncludesClassName(string elementText, string className)
        {
            Assert.That(Page.Item(elementText).WithClass(className).Displayed, Is.True);
        }

        [StepArgumentTransformation]
        public string[] ConvertCommaSeparatedStringToStringArray(string commaSeparatedValue)
        {
            return commaSeparatedValue.Replace(" ", "").Split(",");
        }

        [Then("I can locate element '(.*?)' who class attribute includes multiple class names '(.*?)'")]
        public void ThenICanLocateElementWhoseClassAttributeIncludesMultipleClassNames(string elementText, string[] multipleClassNames)
        {
            Assert.That(Page.Item(elementText).WithClass(multipleClassNames.ToArray()).Displayed, Is.True);
        }
    }
}