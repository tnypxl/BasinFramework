using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers
{
    public abstract class BrowserDecorator : Browser
    {
        private Browser _browser;

        protected BrowserDecorator(Browser browser)
        {
            _browser = browser;
        }

        public void SetBrowser(Browser browser)
        {
            _browser = browser;
        }

        public override IWebDriver Driver => _browser.Driver;

        public override ChromeOptions ChromeOptions => _browser.ChromeOptions;

        public override ChromeDriverService ChromeDriverService => _browser.ChromeDriverService;

        public override FirefoxDriverService FirefoxDriverService => _browser.FirefoxDriverService;

        public override FirefoxOptions FirefoxOptions => _browser.FirefoxOptions;

        public override InternetExplorerDriverService InternetExplorerDriverService => _browser.InternetExplorerDriverService;

        public override InternetExplorerOptions InternetExplorerOptions => _browser.InternetExplorerOptions;

        public override Browser CreateDriverService(string pathToDriverExecutable = null)
        {
            return _browser.CreateDriverService(pathToDriverExecutable);
        }

        public override Browser CreateDriverOptions(string pathToBrowserExecutable = null)
        {
            return _browser.CreateDriverOptions(pathToBrowserExecutable);
        }

        public override Browser SetVersion(string version = null)
        {
            return _browser.SetVersion(version);
        }

        public override Browser SetPlatformName(string platformName = null)
        {
            return _browser.SetPlatformName(platformName);
        }

        public override Browser EnableHeadlessMode(bool enabled = false)
        {
            return _browser.EnableHeadlessMode(enabled);
        }

        public override Browser SetArguments(params string[] arguments)
        {
            return _browser.SetArguments(arguments);
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