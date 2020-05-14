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
        public IWebDriver GetDriver => new FirefoxDriver(DriverService, DriverOptions, TimeSpan.FromSeconds(BSN.Config.Driver.Timeout));

        /// <inheritdoc />
        public IWebDriver GetRemoteDriver(Uri uri) => new RemoteWebDriver(uri, DriverOptions.ToCapabilities());

        /// <inheritdoc />
        public FirefoxDriverService DriverService => _driverService ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public FirefoxOptions DriverOptions => _driverOptions ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");
    }
}