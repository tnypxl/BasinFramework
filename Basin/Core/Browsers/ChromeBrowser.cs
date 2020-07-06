using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Basin.Core.Browsers
{
    public class ChromeBrowser : Browser
    {
        private ChromeDriverService _service;

        private ChromeOptions _options;

        public override IWebDriver Driver =>
            BSN.Config.Browser.Host == null
                ? new ChromeDriver(ChromeDriverService, ChromeOptions)
                : new RemoteWebDriver(BSN.Config.Browser.Host, ChromeOptions);

        public override ChromeOptions ChromeOptions => _options;

        public override ChromeDriverService ChromeDriverService => _service;

        public override Browser CreateDriverService(string pathToDriverExecutable = null)
        {
            _service = string.IsNullOrEmpty(pathToDriverExecutable)
                ? ChromeDriverService.CreateDefaultService()
                : ChromeDriverService.CreateDefaultService(pathToDriverExecutable);

            return this;
        }

        public override Browser CreateDriverOptions(string pathToBrowserExecutable = null)
        {
            _options = new ChromeOptions();

            if (string.IsNullOrEmpty(pathToBrowserExecutable))
                _options.BinaryLocation = pathToBrowserExecutable;

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
            if (!enabled) return this;

            _options.AddArguments("--headless", "--disable-gpu");

            return this;
        }

        public override Browser SetArguments(params string[] arguments)
        {
            if (arguments?.Any() != true) return this;

            _options.AddArguments(arguments);

            return this;
        }

        public override Browser SetOptions(ChromeOptions options)
        {
            _options = options;

            return this;
        }
    }
}