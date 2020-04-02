using Basin.Pages.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Pages
{
    public abstract class PageMap : IPageMap
    {
        public Element Locate(string selector) => Driver.Locate(selector);

        public Element Locate(By @by) => Driver.Locate(by);

        public Element LocateInside(string selector, string parentSelector) => Driver.LocateInside(selector, parentSelector);

        public Element LocateInside(By @by, By parentBy) => Driver.LocateInside(by, parentBy);

        public Elements LocateAll(string selector) => Driver.LocateAll(selector);

        public Elements LocateAll(By @by) => Driver.LocateAll(by);

        public Elements LocateAllInside(string selector, string parentSelector) => Driver.LocateAllInside(selector, parentSelector);

        public Elements LocateAllInside(By @by, By parentBy) => Driver.LocateAllInside(by, parentBy);
    }
}