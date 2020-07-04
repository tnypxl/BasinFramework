using System;
using System.Collections.Generic;
using Basin.Core.Browsers;
using Basin.Core.Browsers.Interfaces;

namespace Basin.Selenium
{
    public static class BrowserFactory
    {
        private static readonly Dictionary<string, Browser> SupportedBrowsers = new Dictionary<string, Browser>()
        {
            { "chrome", new ChromeBrowser() },
            { "firefox", new FirefoxBrowser() },
            { "internet explorer", new InternetExplorerBrowser() }
        };
        
        public static Browser Current => new ConfiguredBrowserDecorator(SupportedBrowsers[BSN.Config.Browser.Kind]);
    }
}