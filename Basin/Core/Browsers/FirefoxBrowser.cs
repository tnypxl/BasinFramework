using System;
using Basin.Config.Interfaces;
using Basin.Core.Browsers.Interfaces;
using Basin.Core.Browsers.Mappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Basin.Core.Browsers
{
    public class FirefoxBrowser : IFirefoxBrowser
    {
        public FirefoxBrowser()
        {
        }

        public FirefoxBrowser(IBrowserConfig config)
        {
            Service = new FirefoxServiceMapper(config).Service;
            Options = new FirefoxOptionsMapper(config).Options;

            CreateDriver(config.Host);
        }

        public FirefoxDriverService Service { get; set; }

        public FirefoxOptions Options { get; set; }

        public IWebDriver Driver { get; set; }

        public void CreateDriver(Uri host = null)
        {
            Driver = host == null
                ? new FirefoxDriver(Service, Options)
                : new RemoteWebDriver(host, Options);
        }
    }
}