using System;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Builders
{
    /// <summary>
    ///     Concrete Driver Builder for Firefox
    /// </summary>
    public class FirefoxBuilder : IFirefoxBuilder
    {
        private FirefoxOptions _driverOptions;
        private Proxy _driverProxy;
        private FirefoxDriverService _driverService;

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = FirefoxDriverService.CreateDefaultService(BSN.DriverPath);
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new FirefoxOptions();
        }

        /// <inheritdoc />
        public void CreateProxy(Proxy proxy)
        {
            _driverProxy = proxy;
        }

        /// <inheritdoc />
        public IWebDriver GetDriver => new FirefoxDriver(DriverService, DriverOptions, TimeSpan.FromSeconds(BSN.Config.Driver.Timeout));


        public IWebDriver GetRemoteDriver(Uri uri)
        {
            return new RemoteWebDriver(uri, DriverOptions.ToCapabilities());
        }

        /// <inheritdoc />
        public Proxy DriverProxy => _driverProxy ?? throw new NullReferenceException("_driverProxy is null. Create CreateProxy().");

        /// <inheritdoc />
        public FirefoxDriverService DriverService => _driverService ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public FirefoxOptions DriverOptions => _driverOptions ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");

        /// <inheritdoc cref="CreateProxy(Proxy)" />
        public void CreateProxy()
        {
            CreateProxy(new Proxy());
        }
    }
}