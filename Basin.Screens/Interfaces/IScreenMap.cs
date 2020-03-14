using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Screens.Interfaces
{
    public interface IScreenMap<TElement, TElements>
    {
        TElement Locate(By by);
        TElement Locate(string css);
        TElements LocateAll(By by);
    }
}