using Basin.Tests.Pages.Shared;
using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.Pages
{
    public class HomePage : Page<HomePageMap>
    {
        public HomePage PerformSearch(string query)
        {
            Map.SearchField.SendKeys(query);
            Map.SearchButton.Click();

            return this;
        }
    }

    public class HomePageMap : PageMap
    {
        private const string HomePageContainer = "#pg-index.body--home";

        private readonly SearchFieldMap _searchField = new SearchFieldMap();

        public Element SearchField => _searchField.FromHomepage;

        public Element SearchButton => Locate(By.Id("search_button_homepage"));

        public Element Container => Locate(By.CssSelector(HomePageContainer));
    }
}
