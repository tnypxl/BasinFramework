using System;
using System.Collections.Generic;
using Basin.Selenium.Builders;
using Basin.Selenium.Interfaces;

namespace Basin.Selenium
{
    public static class DriverFactory
    {
        private static readonly Dictionary<string, Func<IDriverBuilder>> _builders = new Dictionary<string, Func<IDriverBuilder>>
            {
                { "chrome", () => new ChromeBuilder(BSN.Config.Driver) },
                { "firefox", () => new FirefoxBuilder(BSN.Config.Driver) },
                { "edge", () => new EdgeBuilder(BSN.Config.Driver) },
                { "ie", () => new InternetExplorerBuilder(BSN.Config.Driver) }
            };

        public static Func<IDriverBuilder> GetBuilder => _builders[BSN.Config.Driver.BrowserName];
    }
}