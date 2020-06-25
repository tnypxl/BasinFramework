using System;
using Basin.Config.Interfaces;
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

        private InternetExplorerDriverService _driverService;

        private readonly IDriverConfig _config;

        public InternetExplorerBuilder(IDriverConfig config)
        {
            _config = config;

            CreateService();
            CreateOptions();
            SetPlatformName();
            SetPageLoadStrategy();
            SetBrowserVersion();
        }

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = InternetExplorerDriverService.CreateDefaultService(_config.PathToDriver);
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new InternetExplorerOptions();
        }

        public void SetPlatformName()
        {
            if (string.IsNullOrEmpty(_config.PlatformName)) return;

            _driverOptions.PlatformName = _config.PlatformName;
        }

        public void SetBrowserVersion()
        {
            if (string.IsNullOrEmpty(_config.BrowserVersion)) return;

            _driverOptions.BrowserVersion = _config.BrowserName;
        }

        public void SetPageLoadStrategy()
        {
            if (string.IsNullOrEmpty(_config.PageLoadStrategy)) return;

            _driverOptions.PageLoadStrategy = DriverConfig.PageLoadStrategies[_config.PageLoadStrategy];
        }

        /// <inheritdoc />
        public IWebDriver GetDriver => _config.Host == null
            ? new InternetExplorerDriver(DriverService, DriverOptions)
            : new RemoteWebDriver(_config.Host, DriverOptions);

        /// <inheritdoc />
        public InternetExplorerDriverService DriverService => _driverService
            ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public InternetExplorerOptions DriverOptions => _driverOptions
            ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");
    }
}