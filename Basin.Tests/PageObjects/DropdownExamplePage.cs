using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class DropdownExamplePage : Page
    {
        public Element SelectList => SelectListTag.WithId("dropdown");
    }
}
