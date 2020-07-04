using OpenQA.Selenium.Chrome;

namespace Basin.Core.Browsers.Interfaces
{
    public interface IChromeBrowser : IBrowser
    {
        ChromeDriverService Service { get; set; }

        ChromeOptions Options { get; set; }
    }
}