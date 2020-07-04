using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Basin.Core.Browsers.Interfaces
{
    public interface IFirefoxBrowser : IBrowser
    {
        FirefoxDriverService Service { get; set; }

        FirefoxOptions Options { get; set; }
    }
}