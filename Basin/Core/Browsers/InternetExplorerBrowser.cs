using System;
using Basin.Config.Interfaces;
using Basin.Core.Browsers.Interfaces;
using Basin.Core.Browsers.Mappers;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Basin.Core.Browsers
{
    public class InternetExplorerBrowser : IInternetExplorerBrowser
    {
        public InternetExplorerBrowser(IBrowserConfig config)
        {
            Service = new InternetExplorerServiceMapper(config).Service;
            Options = new InternetExplorerOptionsMapper(config).Options;

            CreateDriver(config.Host);
        }

        public InternetExplorerDriverService Service { get; set; }

        public InternetExplorerOptions Options { get; set; }

        public IWebDriver Driver { get; set; }

        public void CreateDriver() => CreateDriver(null);

        public void CreateDriver(Uri host)
        {
            Driver = (host == null)
                ? new InternetExplorerDriver(Service, Options)
                : new RemoteWebDriver(host, Options);
        }
    }
}