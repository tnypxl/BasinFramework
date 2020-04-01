using Basin.Pages.Interfaces;
using Basin.Selenium;

namespace Basin.Pages
{
    public abstract class Page : IPageBase
    {
        protected Page() {}
        
        public Wait Wait { get; set; } = Driver.Wait;

        public TPage On<TPage>() where TPage : new() => new TPage();
    }

    public abstract class Page<TPageMap> : Page
    {
        protected Page(TPageMap map)
        {
            Map = map;
        }

        public TPageMap Map;
    }

}