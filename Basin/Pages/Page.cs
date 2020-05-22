using System;
using Basin.Pages.Interfaces;
using Basin.Selenium;

namespace Basin.Pages
{
    public abstract class Page : PageMap, IPageBase
    {
        public Wait Wait => Driver.Wait;
        
        public TPage On<TPage>() where TPage : new() => new TPage();
    }

    public abstract class Page<TPageMap> : IPageBase where TPageMap : new()
    {
        private TPageMap _map;
        public Wait Wait => Driver.Wait;

        public TPage On<TPage>() where TPage : new() => new TPage();

        public TPageMap Map => _map = new TPageMap();
    }

    public abstract class PageComponent : Page { }

    public abstract class PageComponent<TPageComponentMap> : Page<TPageComponentMap> where TPageComponentMap : new()
    { }

}