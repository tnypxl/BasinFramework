using System;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Builders
{
    /// <summary>
    ///     Concrete Driver Builder for InternetExplorer
    /// </summary>
    public class InternetExplorerBuilder : IInternetExplorerBuilder
    {
        private InternetExplorerOptions _driverOptions;
        private Proxy _driverProxy;
        private InternetExplorerDriverService _driverService;

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = InternetExplorerDriverService.CreateDefaultService(BSN.DriverPath);
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new InternetExplorerOptions();
        }

        /// <inheritdoc />
        public void CreateProxy(Proxy proxy)
        {
            _driverProxy = proxy;
        }


        /// <inheritdoc />
        public IWebDriver GetDriver => new InternetExplorerDriver(DriverService, DriverOptions, TimeSpan.FromSeconds(BSN.Config.Driver.Timeout));


        /// <inheritdoc />
        public IWebDriver GetRemoteDriver(Uri uri)
        {
            return new RemoteWebDriver(uri, DriverOptions.ToCapabilities());
        }

        /// <inheritdoc />
        public Proxy DriverProxy => _driverProxy ?? throw new NullReferenceException("_driverProxy is null. Create CreateProxy().");

        /// <inheritdoc />
        public InternetExplorerDriverService DriverService => _driverService ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public InternetExplorerOptions DriverOptions => _driverOptions ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");

        /// <inheritdoc cref="CreateProxy(Proxy)" />
        public void CreateProxy()
        {
            CreateProxy(new Proxy());
        }
    }
}