using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample.Pages.Shared
{
    public class SearchFieldMap : PageMap
    {
        public Element FromHomepage => TextField.WithId("search_form_input_homepage");
        
        public Element FromResults => TextField.WithId("search_form_input");
    }
}