using System;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Builders
{
    /// <summary>
    ///     Concrete Driver Builder for Chrome
    /// </summary>
    public class ChromeBuilder : IChromeBuilder
    {
        private ChromeOptions _driverOptions;
        private Proxy _driverProxy;
        private ChromeDriverService _driverService;

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = ChromeDriverService.CreateDefaultService(BSN.DriverPath);
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new ChromeOptions();
        }

        /// <inheritdoc />
        public void CreateProxy(Proxy proxy)
        {
            _driverProxy = proxy;
        }


        /// <inheritdoc />
        public IWebDriver GetDriver => new ChromeDriver(DriverService, DriverOptions, TimeSpan.FromSeconds(BSN.Config.Driver.Timeout));


        /// <inheritdoc />
        public IWebDriver GetRemoteDriver(Uri uri)
        {
            return new RemoteWebDriver(uri, DriverOptions.ToCapabilities());
        }

        /// <inheritdoc />
        public Proxy DriverProxy => _driverProxy ?? throw new NullReferenceException("_driverProxy is null. Call CreateProxy().");

        /// <inheritdoc />
        public ChromeDriverService DriverService => _driverService ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public ChromeOptions DriverOptions => _driverOptions ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");

        /// <inheritdoc cref="CreateProxy(Proxy)" />
        public void CreateProxy()
        {
            CreateProxy(new Proxy());
        }
    }
}