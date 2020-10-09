using System;
using Basin.PageObjects;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;

namespace Basin.PageObjects
{
    public delegate void Screens();

    public abstract class Page : PageMap, IPageBase
    {
        protected readonly PageActor I;
        protected Page() => I = new PageActor();
        public Wait Wait => BrowserSession.Wait;
        
    }

        // public TPage On<TPage>() where TPage : new() => new TPage();
    }

    public abstract class Page<TPageMap> : IPageBase where TPageMap : new()
    {
        protected readonly PageActor I;
        
        protected Page() => I = new PageActor();

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