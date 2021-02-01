using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class InputsExamplePage : Page
    {
        public Element NumberField => InputTag.WithAttr("type", "number");
    }
}
