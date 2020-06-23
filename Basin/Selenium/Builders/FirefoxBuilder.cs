using System.Linq;
using System;
using Basin.Config.Interfaces;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Builders
{
    /// <summary>
    ///     Concrete Builder for Firefox
    /// </summary>
    public class FirefoxBuilder : IFirefoxBuilder
    {
        private FirefoxOptions _driverOptions;

        private FirefoxDriverService _driverService;

        private readonly IDriverConfig _config;

        public FirefoxBuilder()
        {
            _config = new DriverConfig()
            {
                BrowserName = "firefox"
            };

            CreateService();
            CreateOptions();
        }

        public FirefoxBuilder(IDriverConfig config)
        {
            _config = config;

            CreateService();
            CreateOptions();
            EnableHeadlessMode();
            SetPlatformName();
            SetBrowserVersion();
            AddArguments();
        }

        /// <inheritdoc />
        public void CreateService()
        {
            _driverService = FirefoxDriverService.CreateDefaultService();
        }

        /// <inheritdoc />
        public void CreateOptions()
        {
            _driverOptions = new FirefoxOptions();
        }

        public void SetPlatformName()
        {
            if (string.IsNullOrEmpty(_config.PlatformName)) return;

            _driverOptions.PlatformName = _config.PlatformName;
        }

        public void SetBrowserVersion()
        {
            if (string.IsNullOrEmpty(_config.BrowserVersion)) return;

            _driverOptions.BrowserVersion = _config.BrowserVersion;
        }

        public void AddArguments()
        {
            if (_config.Arguments?.Any() != true) return;

            _driverOptions.AddArguments(_config.Arguments);
        }

        public void EnableHeadlessMode()
        {
            if (!_config.Headless) return;

            _driverOptions.AddArgument("-headless");
        }

        public void SetHost()
        {
            if (_config.Host == null) return;

            _driverService.Host = _config.Host.ToString();
        }

        /// <inheritdoc />
        public IWebDriver GetDriver => _config.Host == null
            ? new FirefoxDriver(DriverService, DriverOptions)
            : new RemoteWebDriver(_config.Host, DriverOptions.ToCapabilities());

        /// <inheritdoc />
        public FirefoxDriverService DriverService => _driverService
            ?? throw new NullReferenceException("_driverService is null. Call CreateService().");

        /// <inheritdoc />
        public FirefoxOptions DriverOptions => _driverOptions
            ?? throw new NullReferenceException("_driverOptions is null. Call CreateOptions()");
    }
}