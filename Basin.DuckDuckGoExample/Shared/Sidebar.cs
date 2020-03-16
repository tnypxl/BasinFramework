using Basin.Screens.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample.Shared
{
    public class Sidebar : PageBase, IPage<SidebarMap>
    {
        public SidebarMap Map => new SidebarMap();

        public Sidebar SlideOpen()
        {
            Map.HamburgerButton.Click();
            Wait.Until(Map.Container.IsDisplaying);
            
            return this;
        }

        public void ViewThemeSettings()
        {
            Map.Themes.Click();
        }

        public void ViewOtherSettings()
        {
            Map.OtherSettings.Click();
        }

        public void ViewAppsAndExtensions()
        {
            Map.AppsAndExtensions.Click();
        }

        public void ViewBangSearchShortcuts()
        {
            Map.BangSearchShortcuts.Click();
        }
    }

    public class SidebarMap : PageMapBase, IPageMap
    {
        private const string SidebarContainer = ".nav-menu--slideout.is-open";
        
        private static readonly string NavMenuItem = $"{SidebarContainer} .nav-menu__item";
        
        private static By LinkBy(string url) => By.CssSelector($"{NavMenuItem} a[href='{url}']");

        public Element Container => Locate(By.CssSelector(SidebarContainer));

        public Element HamburgerButton => Locate(By.CssSelector(".header--aside .header__button--menu.js-side-menu-open"));

        public Element Themes => Locate(LinkBy("https://duckduckgo.com/settings#theme"));
        
        public Element OtherSettings => Locate(LinkBy("https://duckduckgo.com/settings"));
        
        public Element BangSearchShortcuts => Locate(LinkBy("https://duckduckgo.com/bangs"));

        public Element AppsAndExtensions => Locate(LinkBy("https://duckduckgo.com/apps"));
    }
}