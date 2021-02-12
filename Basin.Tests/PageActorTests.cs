using Basin.PageObjects;
using Basin.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Basin.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class PageActorTests : TestBase
    {
        private static PageActor I { get; } = new();

        private HomePage HomePage => Pages.Get<HomePage>();

        private CheckboxesExamplePage CheckboxesPage => Pages.Get<CheckboxesExamplePage>();

        private InputsExamplePage InputsPage => Pages.Get<InputsExamplePage>();

        private KeyPressesExamplePage KeyPressesPage => Pages.Get<KeyPressesExamplePage>();

        private DynamicControlsExamplePage DynamicControlsPage => Pages.Get<DynamicControlsExamplePage>();

        private DynamicLoadingExamplePage DynamicLoadingPage => Pages.Get<DynamicLoadingExamplePage>();

        private AddRemoveElementsExamplePage AddRemoveElementsPage => Pages.Get<AddRemoveElementsExamplePage>();

        private LargeAndDeepDomExamplePage LargeAndDeepDomPage => Pages.Get<LargeAndDeepDomExamplePage>();

        private DropdownExamplePage DropdownPage => Pages.Get<DropdownExamplePage>();

        [Test, Category("Integration")]
        public void ActorCanToggleOnCheckbox()
        {
            I.Click(HomePage.ExampleLink("Checkboxes"));

            Assert.That(CheckboxesPage.FirstCheckbox.GetAttribute("checked"), Is.Null);

            I.CheckOption(CheckboxesPage.FirstCheckbox);

            Assert.That(CheckboxesPage.FirstCheckbox.GetAttribute("checked"), Is.EqualTo("true"));
        }

        [Test, Category("Integration")]
        public void ActorCanToggleCheckbox()
        {
            I.Click(HomePage.ExampleLink("Checkboxes"));

            Assert.That(CheckboxesPage.SecondCheckbox.GetAttribute("checked"), Is.EqualTo("true"));

            I.UncheckOption(CheckboxesPage.SecondCheckbox);

            Assert.That(CheckboxesPage.SecondCheckbox.GetAttribute("checked"), Is.Null);
        }

        [Test, Category("Integration")]
        public void ActorCanAndCannotSeeElement()
        {
            I.Click(HomePage.ExampleLink("Checkboxes"));

            Assert.That(I.See(CheckboxesPage.FirstCheckbox), Is.True);
            Assert.That(I.DontSee(CheckboxesPage.FirstCheckbox.WithAttr("checked")), Is.True);
        }

        [Test, Category("Integration")]
        public void ActorCanEnterText()
        {
            I.Click(HomePage.ExampleLink("Inputs"));
            I.EnterText("200", InputsPage.NumberField);

            Assert.That(InputsPage.NumberField.GetAttribute("value"), Is.EqualTo("200"));
        }

        [Test, Category("Integration")]
        public void ActorCanPressKeys()
        {
            I.Click(HomePage.ExampleLink("Key Presses"));
            I.PressKey(Keys.Alt);

            Assert.That(KeyPressesPage.Result.Text, Is.EqualTo("You entered: ALT"));
        }

        [Test, Category("Integration")]
        public void ActorCanWaitForElement()
        {
            I.Click(HomePage.ExampleLink("Dynamic Controls"));
            I.Click(DynamicControlsPage.Map.RemoveCheckboxButton);

            Assert.DoesNotThrow(() => I.WaitForElement(DynamicControlsPage.Map.Message("It's gone!")));
        }

        [Test, Category("Integration")]
        public void ActorCanGetAndSeeNumberOfElements()
        {
            I.Click(HomePage.ExampleLink("Add/Remove Elements"));
            AddRemoveElementsPage.AddMultipleElements(5);

            Assert.That(I.GetNumberOfElements(AddRemoveElementsPage.Map.DeleteButton), Is.EqualTo(5));
        }

        [Test, Category("Integration")]
        public void ActorCanSeeText()
        {
            I.Click(HomePage.ExampleLink("Dynamic Controls"));
            I.Click(DynamicControlsPage.Map.RemoveCheckboxButton);
            I.WaitForElement(DynamicControlsPage.Map.MessageContainer);

            Assert.That(I.SeeText("It's gone!"), Is.True);

            I.Click(DynamicControlsPage.Map.AddCheckboxButton);
            I.Wait.Until(_ => !DynamicControlsPage.Map.AddCheckboxButton.Displayed);

            Assert.That(I.SeeText("It's back!", DynamicControlsPage.Map.MessageContainer));
        }

        [Test, Category("Integration")]
        public void ActorCanWaitForNumberOfElements()
        {
            I.Click(HomePage.ExampleLink("Dynamic Loading"));
            I.Click(DynamicLoadingPage.ExampleTwoLink);
            I.Click(DynamicLoadingPage.StartButton);

            Assert.DoesNotThrow(() => I.WaitForNumberOfElements(1, DynamicLoadingPage.FinishText));
        }

        [Test, Category("Integration")]
        public void ActorCanSeeNumberOfElements()
        {
            I.Click(HomePage.ExampleLink("Add/Remove Elements"));
            AddRemoveElementsPage.AddMultipleElements(3);

            Assert.That(I.SeeNumberOfElements(3, AddRemoveElementsPage.Map.DeleteButton), Is.True);
        }

        [Test, Category("Integration")]
        public void ActorCanSelectOptionFromSelectList()
        {
            I.Click(HomePage.ExampleLink("Dropdown"));
            I.SelectOptionByText("Option 1", DropdownPage.SelectList);

            Assert.That(DropdownPage.SelectList.Child().WithText("Option 1").Selected, Is.True);

            I.SelectOptionByValue("2", DropdownPage.SelectList);

            Assert.That(DropdownPage.SelectList.Child().WithText("Option 2").Selected, Is.True);
            Assert.Throws<WebDriverTimeoutException>(() => I.SelectOptionByText("Option 3", DropdownPage.SelectList));
        }

        [Test, Category("Integration")]
        public void ActorCanExecuteScriptThatReturnsText()
        {
            I.Click(HomePage.ExampleLink("Large & Deep DOM"));
            var elementText = I.ExecuteScript("return document.getElementById('sibling-2.2').textContent");

            Assert.That(elementText, Is.InstanceOf<string>());
            Assert.That(elementText, Is.EqualTo("2.2"));
        }

        [Test, Category("Integration")]
        public void ActorCanExecuteScriptThatReturnsAnIWebElement()
        {
            I.Click(HomePage.ExampleLink("Large & Deep DOM"));

            var actualElement = LargeAndDeepDomPage.Item("2.2");
            var element = I.ExecuteScript("return arguments[0];", actualElement);
            var webElement = (IWebElement) element;

            Assert.That(element, Is.InstanceOf<IWebElement>());
            Assert.That(webElement.Displayed, Is.True);
        }
    }
}
