using Basin.Pages.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Pages
{
    public abstract class PageMap : IPageMap
    {
        private readonly IWebDriver _driver = Driver.Current;


        public Element Locate(By by) => new Element(by);
        
        public Element Locate(By by, int timeout) => new Element(by, timeout);

        public Element LocateInside(By by, By parentBy) => new Element(by, parentBy);
        
        public Element LocateInside(By by, By parentBy, int timeout) => new Element(by, parentBy, timeout);

        public Elements LocateAll(By by) => new Elements(_driver.FindElements(by));

        public Elements LocateAllInside(By by, By parentBy) => new Elements(Locate(parentBy).FindElements(by));
        
        public Elements LocateAllInside(By by, By parentBy, int timeout) => new Elements(Locate(parentBy, timeout).FindElements(by));

        public string CssClassXPath(string className) => $"contains(concat(' ',normalize-space(@class),' '),' {className} ')";

        public string TextXPath(string text) => $"contains(., '{text}')";
    }
}