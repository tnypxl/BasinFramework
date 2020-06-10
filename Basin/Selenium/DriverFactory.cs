using System;
using System.Collections.Generic;
using Basin.Selenium.Drivers;
using Basin.Selenium.Interfaces;

namespace Basin.Selenium
{
    public static class DriverFactory
    {
        public static readonly Dictionary<string, Func<IDriverBuilder>> Builders = new Dictionary<string, Func<IDriverBuilder>>
        {
            {"chrome", Chrome.Default},
            {"firefox", Firefox.Default},
            {"internet explorer", InternetExplorer.Default},
            {"edge", Edge.Default},
        };
    }
}