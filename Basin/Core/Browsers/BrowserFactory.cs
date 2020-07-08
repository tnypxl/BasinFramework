using System.Collections.Generic;

namespace Basin.Core.Browsers
{
    public static class BrowserFactory
    {
        private static readonly Dictionary<string, Browser> SupportedBrowsers = new Dictionary<string, Browser>()
        {
            { "chrome", new ChromeBrowser() },
            { "firefox", new FirefoxBrowser() },
            { "internet explorer", new InternetExplorerBrowser() }
        };

        public static Browser Current => new ConfiguredBrowserDecorator(SupportedBrowsers[Basin.Config.Browser.Kind]);
    }
}