using System.Collections.Generic;
using System.Linq;
using Basin.Config.Interfaces;
using Basin.Core.Browsers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Basin.Core.Browsers
{
    public class FirefoxBrowser : Browser
    {
        private FirefoxDriverService _service;
        
        private FirefoxOptions _options;

        public override IWebDriver Driver => 
            BSN.Config.Browser.Host == null
                ? new FirefoxDriver(FirefoxDriverService, FirefoxOptions)
                : new RemoteWebDriver(BSN.Config.Browser.Host, FirefoxOptions);

        public override FirefoxDriverService FirefoxDriverService => _service;
        
        public override FirefoxOptions FirefoxOptions => _options;

        public override Browser CreateDriverService(string pathToDriverExecutable = null)
        {
            _service = string.IsNullOrEmpty(pathToDriverExecutable)
                ? FirefoxDriverService.CreateDefaultService()
                : FirefoxDriverService.CreateDefaultService(pathToDriverExecutable);

            return this;
        }

        public override Browser CreateDriverOptions(string pathToBrowserExecutable = null)
        {
            _options = new FirefoxOptions();

            if (string.IsNullOrEmpty(pathToBrowserExecutable))
                _options.BrowserExecutableLocation = pathToBrowserExecutable;

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
            
            _options.AddArgument("-headless");
        
            return this;
        }
        
        public override Browser SetArguments(params string[] arguments)
        {
            if (arguments == null || !arguments.Any()) return this;
        
            _options.AddArguments(arguments);
        
            return this;
        }
        
        public override Browser SetOptions(FirefoxOptions options)
        {
            _options = options;

            return this;
        }
    }
}