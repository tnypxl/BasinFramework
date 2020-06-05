using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.Pages.Shared
{
    public class Sidebar : Page<SidebarMap>
    {

        public Sidebar SlideOpen()
        {
            Map.HamburgerMenu.Click();
            Wait.Until(Map.Container.IsDisplaying);

            return this;
        }

        public Sidebar ViewThemeSettings()
        {
            Map.Themes.Click();

            return this;
        }

        public Sidebar ViewOtherSettings()
        {
            Map.OtherSettings.Click();

            return this;
        }

        public Sidebar ViewAppsAndExtensions()
        {
            Map.AppsAndExtensions.Click();

            return this;
        }

        public Sidebar ViewBangSearchShortcuts()
        {
            Map.BangSearchShortcuts.Click();

            return this;
        }
    }

    public class SidebarMap : PageMap
    {
        private const string SidebarContainer = ".nav-menu--slideout.is-open";

        private static readonly string NavMenuItem = $"{SidebarContainer} .nav-menu__item";

        public Element HamburgerMenu => Locate(By.CssSelector(".header--aside .header__button--menu.js-side-menu-open"));

        public Element Themes => Locate(LinkBy("https://duckduckgo.com/settings#theme"));

        public Element OtherSettings => Locate(LinkBy("https://duckduckgo.com/settings"));

        public Element BangSearchShortcuts => Locate(LinkBy("https://duckduckgo.com/bangs"));

        public Element AppsAndExtensions => Locate(LinkBy("https://duckduckgo.com/apps"));

        public Element Container => Locate(By.CssSelector(SidebarContainer));

        private static By LinkBy(string url)
        {
            return By.CssSelector($"{NavMenuItem} a[href='{url}']");
        }
    }

    public class FooClass
    {
        public void Foo() { }
    }
}
