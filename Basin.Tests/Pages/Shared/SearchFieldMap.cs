using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.Pages.Shared
{
    public class SearchFieldMap : PageMap
    {
        public Element FromHomepage => TextInputTag.WithId("search_form_input_homepage");

        public Element FromResults => TextInputTag.WithId("search_form_input");
    }
}