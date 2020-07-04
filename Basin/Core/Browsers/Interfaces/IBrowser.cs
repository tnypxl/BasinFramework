using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers.Interfaces
{
    public interface IBrowser
    {
        IWebDriver Driver { get; }
    }
}