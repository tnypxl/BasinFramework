using Basin.Selenium;
using Basin.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Basin.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ElementTests : TestBase
    {
        private HomePage HomePage => Pages.Get<HomePage>();

        private AddRemoveElementsExamplePage AddRemoveElementsPage => Pages.Get<AddRemoveElementsExamplePage>();

        private LargeAndDeepDomExamplePage LargeAndDeepDomPage => Pages.Get<LargeAndDeepDomExamplePage>();

        [Test, Category("Integration")]
        public void ElementIsAnInstanceOfIWebElement()
        {
            Assert.That(new Element(), Is.InstanceOf<IWebElement>());
        }

        [Test, Category("Integration")]
        public void ElementCanReceiveAClick()
        {
            HomePage.NavigateToExample("Add/Remove Elements");
            AddRemoveElementsPage.Map.AddElementButton.Click();

            Assert.That(AddRemoveElementsPage.Map.DeleteButton.All.Count, Is.EqualTo(1));
        }

        [Test, Category("Integration")]
        public void ElementCanBeLocatedInsideAnotherElement()
        {
            HomePage.NavigateToExample("Large & Deep DOM");

            Assert.That(LargeAndDeepDomPage.Item("2.1").Inside(LargeAndDeepDomPage.Item("1.1")).Displayed);
        }
    }
}
