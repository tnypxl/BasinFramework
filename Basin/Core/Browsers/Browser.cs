using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers
{
    public abstract class Browser
    {
        public abstract IWebDriver Driver { get; }

        public abstract Browser CreateDriverService(string pathToDriverExecutable = null);

        public abstract Browser CreateDriverOptions(string pathToBrowserExecutable = null);

        public abstract Browser SetVersion(string version = null);

        public abstract Browser SetPlatformName(string platformName = null);

        public abstract Browser EnableHeadlessMode(bool enabled = false);

        public abstract Browser SetArguments(params string[] arguments);

        #region Chrome Interfaces

        public virtual Browser SetOptions(ChromeOptions options) => null;

        public virtual ChromeOptions ChromeOptions => null;

        public virtual ChromeDriverService ChromeDriverService => null;

        #endregion

        #region Firefox Interfaces

        public virtual Browser SetOptions(FirefoxOptions options) => null;

        public virtual FirefoxOptions FirefoxOptions => null;

        public virtual FirefoxDriverService FirefoxDriverService => null;

        #endregion

        #region Internet Explorer Interfaces

        public virtual Browser SetOptions(InternetExplorerOptions options) => null;

        public virtual InternetExplorerOptions InternetExplorerOptions => null;

        public virtual InternetExplorerDriverService InternetExplorerDriverService => null;

        #endregion
    }
}