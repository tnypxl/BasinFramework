using System.Collections.Generic;
using Basin.Screens.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample.Shared
{
    public class SearchField : PageBase, IPage<SearchFieldMap>
    {
        public SearchFieldMap Map => new SearchFieldMap();
    }

    public class SearchFieldMap : PageMapBase
    {
        public Element HomePage => Locate(By.Id("search_form_input_homepage"));
        
        public Element AnyPage => Locate(By.Id("search_form_input"));
    }
}