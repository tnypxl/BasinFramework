using Basin.Screens.Interfaces;

namespace Basin.DuckDuckGoExample
{
    public class ResultsPage : PageBase, IPage<ResultsPageMap>
    {
        public ResultsPageMap Map => new ResultsPageMap();
    }

    public class ResultsPageMap : PageMapBase
    {
    }
}