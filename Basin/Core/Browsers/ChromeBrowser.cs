using System;
using Basin.Config.Interfaces;
using Basin.Core.Browsers.Interfaces;
using Basin.Core.Browsers.Mappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Basin.Core.Browsers
{
    public class ChromeBrowser : IChromeBrowser
    {
        public ChromeBrowser(IBrowserConfig config)
        {
            Service = new ChromeServiceMapper(config).Service;
            Options = new ChromeOptionsMapper(config).Options;

            CreateDriver(config.Host);
        }

        public ChromeDriverService Service { get; set; }

        public ChromeOptions Options { get; set; }

        public IWebDriver Driver { get; set; }

        public void CreateDriver() => CreateDriver(null);

        public void CreateDriver(Uri host)
        {
            Driver = (host == null)
                ? new ChromeDriver(Service, Options)
                : new RemoteWebDriver(host, Options);
        }
    }
}