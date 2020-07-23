using System;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;

namespace Basin.PageObjects
{
    public abstract class Page : PageMap, IPageBase
    {
        public Wait Wait => BrowserSession.Wait;

        // public TPage On<TPage>() where TPage : new() => new TPage();
    }

    public abstract class Page<TPageMap> : IPageBase where TPageMap : new()
    {
        private readonly TPageMap _map = new TPageMap();

        public Wait Wait => BrowserSession.Wait;

        // public TPage On<TPage>() where TPage : new() => new TPage();

        public TPageMap Map => _map ?? throw new NullReferenceException("Map is null. Set with an instance of PageMap");
    }

    public abstract class PageComponent : Page { }

    public abstract class PageComponent<TPageComponentMap> : Page<TPageComponentMap> where TPageComponentMap : new() { }
}