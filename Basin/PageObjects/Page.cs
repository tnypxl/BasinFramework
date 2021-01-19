using Basin.PageObjects.Interfaces;
using Basin.Selenium;

namespace Basin.PageObjects
{
    public abstract class Page : PageMap, IPageBase
    {
        public Wait Wait => BrowserSession.Wait;
    }

    public abstract class Page<TPageMap> : IPageBase where TPageMap : new()
    {

        public Wait Wait => BrowserSession.Wait;

        public TPageMap Map { get; } = new TPageMap();
    }

    public abstract class PageComponent : Page { }

    public abstract class PageComponent<TPageComponentMap> : Page<TPageComponentMap> where TPageComponentMap : new() { }

    public abstract class Screen : Page { }

    public abstract class Screen<TScreenMap> : Page<TScreenMap> where TScreenMap : new() { }

    public abstract class ScreenComponent : Page { }

    public abstract class ScreenComponent<TScreenComponentMap> : Page<TScreenComponentMap> where TScreenComponentMap : new() { }
}
