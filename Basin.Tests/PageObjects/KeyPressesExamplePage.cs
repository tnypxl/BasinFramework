using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class KeyPressesExamplePage : Page
    {
        public Element KeyPressField => TextInputTag.WithId("target");

        public Element Result => ParagraphTag.WithId("result");
    }
}
