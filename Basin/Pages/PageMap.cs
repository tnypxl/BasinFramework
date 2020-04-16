using Basin.Pages.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Pages
{
    public abstract class PageMap : IPageMap
    {
        private readonly IWebDriver driver = Driver.Current;


        public Element Locate(By @by) => new Element(@by);

        public Element LocateInside(By @by, By parentBy) => new Element(@by, parentBy);

        public Elements LocateAll(By @by) => new Elements(driver.FindElements(@by));

        public Elements LocateAllInside(By @by, By parentBy) => new Elements(Locate(parentBy).FindElements(@by));

        public string CssClassXPath(string className) => $"contains(concat(' ',normalize-space(@class),' '),' {className} ')";

        public string TextXPath(string text) => $"contains(., '{text}')";
    }
}