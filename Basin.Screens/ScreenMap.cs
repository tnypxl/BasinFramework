using Basin.Screens.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Screens
{
    /// <summary>
    /// A base class that implements the IScreenMap interface.
    /// </summary>
    public abstract class ScreenMap : IScreenMap<Element, Elements>
    {
        public Element Locate(By by) => Driver.Locate(by);

        public Element Locate(string css) => Driver.Locate(css);

        public Elements LocateAll(By by) => Driver.LocateAll(by);
    }
}