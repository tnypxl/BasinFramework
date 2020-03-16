using Basin.DuckDuckGoExample.Shared;
using Basin.Screens.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample
{
    // This class represents all relevant behaviors that can be executed on the DuckDuckGo homepage
    public class HomePage : PageBase, IPage<HomePageMap>
    {
        // This exposes webdriver elements defined in the map class
        public HomePageMap Map => new HomePageMap();
        
        

        // This is a behavior we can execute on this page
        public void PerformSearch(string query)
        {
            Wait.Until(WaitConditions.ElementDisplayed(Map.Container));
            Map.SearchField.SendKeys(query);
            Map.SearchButton.Click();
        }
    }

    // This class holds all the elements defined for the homepage
    public class HomePageMap : PageMapBase, IPageMap
    {
        
        
        private const string HomePageContainer = "#pg-index.body--home";
        public Element Container => Locate(By.CssSelector(HomePageContainer));
        
        public Element SearchField => new SearchField().Map.HomePage;

        public Element SearchButton => Locate(By.Id("search_button_homepage"));
        
    }
}