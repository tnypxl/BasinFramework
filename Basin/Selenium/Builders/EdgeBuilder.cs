using Microsoft.Edge.SeleniumTools;
using System;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Builders
{
    public class EdgeBuilder : IEdgeBuilder
    {
        private EdgeOptions _driverOptions;
        private EdgeDriverService _driverService;

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = EdgeDriverService.CreateDefaultService(BSN.DriverPath);
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new EdgeOptions();
        }

        /// <inheritdoc />
        public IWebDriver GetDriver => new EdgeDriver(DriverService, DriverOptions, TimeSpan.FromSeconds(BSN.Config.Driver.Timeout));

        /// <inheritdoc />
        public IWebDriver GetRemoteDriver(Uri uri) => new RemoteWebDriver(uri, DriverOptions.ToCapabilities());

        /// <inheritdoc />
        public EdgeDriverService DriverService => _driverService ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public EdgeOptions DriverOptions => _driverOptions ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");
    }
}