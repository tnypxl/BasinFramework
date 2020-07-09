using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Basin.Core.Browsers
{
    public class InternetExplorerBrowser : Browser
    {
        private InternetExplorerDriverService _service;

        private InternetExplorerOptions _options;

        public override InternetExplorerDriverService InternetExplorerDriverService => _service;

        public override InternetExplorerOptions InternetExplorerOptions => _options;

        public override IWebDriver Driver =>
            BasinEnv.Browser.Host == null
                ? new InternetExplorerDriver(InternetExplorerDriverService, InternetExplorerOptions)
                : new RemoteWebDriver(BasinEnv.Browser.Host, InternetExplorerOptions);

        public override Browser CreateDriverService(string pathToDriverExecutable = null)
        {
            _service = string.IsNullOrEmpty(pathToDriverExecutable)
                ? InternetExplorerDriverService.CreateDefaultService()
                : InternetExplorerDriverService.CreateDefaultService(pathToDriverExecutable);

            return this;
        }

        public override Browser CreateDriverOptions(string pathToBrowserExecutable = null)
        {
            _options = new InternetExplorerOptions();

            if (!string.IsNullOrEmpty(pathToBrowserExecutable))
                throw new NotSupportedException("InternetExplorerOptions() does not support setting a path to the Internet Explorer browser executable.");

            return this;
        }

        public override Browser SetVersion(string version = null)
        {
            if (string.IsNullOrEmpty(version)) return this;

            _options.BrowserVersion = version;

            return this;
        }

        public override Browser SetPlatformName(string platformName = null)
        {
            if (string.IsNullOrEmpty(platformName)) return this;

            _options.PlatformName = platformName;

            return this;
        }

        public override Browser EnableHeadlessMode(bool enabled = false)
        {
            throw new NotSupportedException("Internet Explorer does not support headless execution.");
        }

        public override Browser SetArguments(params string[] arguments)
        {
            throw new NotSupportedException("InternetExplorerOptions() does support launch arguments, but it requires `ForceCreateServiceApi` to be set to true.");
        }

        public override Browser SetOptions(InternetExplorerOptions options)
        {
            _options = options;

            return this;
        }
    }
}