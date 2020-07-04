using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers.Interfaces
{
    public interface IInternetExplorerBrowser : IBrowser
    {
        InternetExplorerDriverService Service { get; set; }

        InternetExplorerOptions Options { get; set; }
    }
}