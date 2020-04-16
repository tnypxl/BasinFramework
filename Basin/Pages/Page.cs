using Basin.Pages.Interfaces;
using Basin.Selenium;

namespace Basin.Pages
{
    public abstract class Page : PageMap, IPageBase
    {
        public Wait Wait { get; } = Driver.Wait;

        public TPage On<TPage>() where TPage : new() => new TPage();
    }

    public abstract class Page<TPageMap> : IPageBase
    {
        public Wait Wait { get; } = Driver.Wait;

        public TPage On<TPage>() where TPage : new() => new TPage();

        protected TPageMap Map { get; set; }
    }

    public abstract class PageComponent : Page { }

    public abstract class PageComponent<TPageComponentMap> : Page<TPageComponentMap> { }

}