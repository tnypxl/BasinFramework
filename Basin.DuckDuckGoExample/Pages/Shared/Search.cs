using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample.Pages.Shared
{
    public class SearchField : Page<SearchFieldMap>
    {
        public PageCollection SomePageCollection;

        public SearchField(PageCollection someSection)
        {
            SomePageCollection = someSection;
        }
    }

    public class SearchFieldMap : PageMap
    {
        public Element HomePage => Locate(By.Id("search_form_input_homepage"));

        public Element AnyPage => Locate(By.Id("search_form_input"));
    }
}