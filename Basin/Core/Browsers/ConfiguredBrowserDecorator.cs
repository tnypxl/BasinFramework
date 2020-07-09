using System.Linq;
using Basin.Config.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers
{
    public class ConfiguredBrowserDecorator : BrowserDecorator
    {
        private readonly Browser _browser;

        private IBrowserConfig Config { get; } = BasinEnv.Browser;
        public ConfiguredBrowserDecorator(Browser browser) : base(browser)
        {
            _browser = browser;

            CreateDriverService();
            CreateDriverOptions();
            SetVersion();
            SetPlatformName();

            if (Config.Kind == "ie") return;

            SetArguments();
            EnableHeadlessMode();
        }

        public override IWebDriver Driver => _browser.Driver;

        public override ChromeDriverService ChromeDriverService => _browser.ChromeDriverService;

        public override ChromeOptions ChromeOptions => _browser.ChromeOptions;

        public override FirefoxDriverService FirefoxDriverService => _browser.FirefoxDriverService;

        public override FirefoxOptions FirefoxOptions => _browser.FirefoxOptions;

        public override InternetExplorerDriverService InternetExplorerDriverService => _browser.InternetExplorerDriverService;

        public override InternetExplorerOptions InternetExplorerOptions => _browser.InternetExplorerOptions;

        public sealed override Browser CreateDriverService(string pathToDriverExecutable = null)
        {
            return _browser.CreateDriverService(BasinEnv.Browser.PathToDriverBinary);
        }

        public sealed override Browser CreateDriverOptions(string pathToBrowserExecutable = null)
        {
            return _browser.CreateDriverOptions(BasinEnv.Browser.PathToBrowserExecutable);
        }

        public sealed override Browser SetVersion(string version = null)
        {
            return _browser.SetVersion(BasinEnv.Browser.Version);
        }

        public sealed override Browser SetPlatformName(string platformName = null)
        {
            return _browser.SetPlatformName(BasinEnv.Browser.PlatformName);
        }

        public sealed override Browser EnableHeadlessMode(bool enabled = false)
        {
            return _browser.EnableHeadlessMode(BasinEnv.Browser.Headless);
        }

        public sealed override Browser SetArguments(params string[] arguments)
        {
            return _browser.SetArguments(BasinEnv.Browser.Arguments.ToArray());
        }

        public override Browser SetOptions(ChromeOptions options)
        {
            return _browser.SetOptions(options);
        }

        public override Browser SetOptions(FirefoxOptions options)
        {
            return _browser.SetOptions(options);
        }

        public override Browser SetOptions(InternetExplorerOptions options)
        {
            return _browser.SetOptions(options);
        }
    }
}