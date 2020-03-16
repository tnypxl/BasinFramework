using Basin.Screens.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample
{
    public class PageBase : IPageBase
    {
        public Wait Wait => Driver.Wait;
    }

    public class PageMapBase : IPageMapBase
    {
        public Element Locate(By @by) => Driver.Locate(by);

        public Element Locate(string css) => Driver.Locate(css);

        Elements IScreenMapBase.LocateAll(By @by) => Driver.LocateAll(by);
    }
}