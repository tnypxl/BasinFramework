using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class DynamicControlsExamplePage : Page<DynamicControlsExamplePageMap>
    {
        public void RemoveCheckbox()
        {
            Map.RemoveCheckboxButton.Click();
            Wait.Until(Map.Message("It's gone!").IsDisplaying);
        }

        public void AddCheckbox()
        {
            Map.AddCheckboxButton.Click();
            Wait.Until(Map.Message("It's back!").IsDisplaying);
        }

        public void EnableTextField()
        {
            Map.EnableTextFieldButton.Click();
            Wait.Until(Map.Message("It's enabled!").IsDisplaying);
        }

        public void DisableTextField()
        {
            Map.DisableTextFieldButton.Click();
            Wait.Until(Map.Message("It's disabled!").IsDisplaying);
        }

        public bool TextFieldIsEnabled()
        {
            return Map.TextField.Enabled;
        }

        public bool CheckboxDisplayed()
        {
            return Map.Checkbox.Displayed;
        }
    }

    public class DynamicControlsExamplePageMap : PageMap
    {
        private Element AddRemoveButton => ButtonTag.WithAttr("onclick", "swapCheckbox()");

        private Element EnableDisableButton => ButtonTag.WithAttr("onclick", "swapInput()");

        public Element Message(string text) => ParagraphTag.WithId("message").WithText(text);

        public Element AddCheckboxButton => AddRemoveButton.WithText("Add");

        public Element RemoveCheckboxButton => AddRemoveButton.WithText("Remove");

        public Element EnableTextFieldButton => EnableDisableButton.WithText("Enable");

        public Element DisableTextFieldButton => EnableDisableButton.WithText("Disable");

        public Element Checkbox => CheckboxInputTag.WithId("checkbox");

        public Element TextField => TextInputTag;
    }
}