using System;
using OpenQA.Selenium;

namespace Basin.Core.Browsers
{
    public static class BrowserFactory
    {
        public static IWebDriver Current => BasinEnv.Browser.Kind switch
        {
            "chrome" => new ChromeBrowser(BasinEnv.Browser).Driver,
            "firefox" => new FirefoxBrowser(BasinEnv.Browser).Driver,
            "ie" => new InternetExplorerBrowser(BasinEnv.Browser).Driver,
            _ => throw new NotSupportedException($"'{BasinEnv.Browser.Kind}' is not a supported browser")
        };

        // public static ChromeBrowser ChromeBrowser(Action<Chrome> browserFunc) => Browser.Use(browserFunc);

        // public static FirefoxBrowser FirefoxBrowser(Action<Firefox> browserFunc) => Browser.Use(browserFunc);

        // public static InternetExplorerBrowser InternetExplorerBrowser(Action<InternetExplorer> browserFunc) => Browser.Use(browserFunc);
    }
}
