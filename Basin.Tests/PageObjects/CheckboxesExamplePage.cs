using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class CheckboxesExamplePage : Page
    {
        public Element FirstCheckbox => CheckboxInputTag.AtPosition(1);

        public Element SecondCheckbox => CheckboxInputTag.AtPosition(2);
    }
}
