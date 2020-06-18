using System;
using Basin.Config.Interfaces;
using Basin.Selenium.Interfaces;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Builders
{
    /// <summary>
    ///     Concrete Builder for Edge
    /// </summary>
    public class EdgeBuilder : IEdgeBuilder
    {
        private EdgeOptions _driverOptions;

        private EdgeDriverService _driverService;

        private readonly IDriverConfig _config;

        public EdgeBuilder(IDriverConfig config)
        {
            _config = config;

            CreateService();
            CreateOptions();
            SetPlatformName();
            SetBrowserVersion();
            AddArguments();
        }

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = EdgeDriverService.CreateDefaultService(_config.PathToDriver);
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new EdgeOptions
            {
                UseChromium = true
            };
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

        public void AddArguments()
        {
            if (_config.Arguments == null || _config.Arguments.Length == 0) return;

            _driverOptions.AddArguments(_config.Arguments);
        }

        /// <inheritdoc />
        public IWebDriver GetDriver => _config.Host == null
            ? new EdgeDriver(DriverService, DriverOptions)
            : new RemoteWebDriver(_config.Host, DriverOptions);

        /// <inheritdoc />
        public EdgeDriverService DriverService => _driverService
            ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public EdgeOptions DriverOptions => _driverOptions
            ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");
    }
}