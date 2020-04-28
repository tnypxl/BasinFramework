using System;
using System.Collections.Generic;
using Basin.Selenium.Builders;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Basin.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string name, object driverService = null, object driverOptions = null)
        {
            var builder = GetDriverBuilder(name.ToLower());
            builder.CreateService(driverService);
            builder.CreateOptions(driverOptions);

            return builder.GetDriver();
        }

        private static IDriverBuilder GetDriverBuilder(string name)
        {
            return Builders.ContainsKey(name)
                ? Builders[name]
                : throw new ArgumentException($"Invalid Argument: There is no driver builder called '{name}'");
        }

        private static Dictionary<string, IDriverBuilder> Builders
        {
            get
            {
                var builders = new Dictionary<string, IDriverBuilder>()
                {
                    {"chrome", new ChromeBuilder()},
                    {"firefox", new FirefoxBuilder()},
                    {"internet explorer", new InternetExplorerBuilder()}
                };

                return builders;
            }
        }
    }
}