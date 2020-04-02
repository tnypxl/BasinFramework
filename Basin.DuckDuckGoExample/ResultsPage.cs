using Basin.Pages;
using Basin.Selenium;

namespace Basin.DuckDuckGoExample
{
    public class ResultsPage : Page<ResultsPageMap>
    {
        protected ResultsPage()
        {
            Map = new ResultsPageMap();
        }
    }

    public class ResultsPageMap : PageMap
    {
    }
}