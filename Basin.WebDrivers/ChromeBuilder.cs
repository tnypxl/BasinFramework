using System.Collections.Generic;
using OpenQA.Selenium;

namespace Basin.WebDrivers
{
    public class ChromeBuilder : IDriverBuilder
    {
        public DriverBuilder AddArguments(params string[] driverArgs)
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder AddCapabilities(Dictionary<string, object> caps)
        {
            throw new System.NotImplementedException();
        }

        public IWebDriver Build()
        {
            throw new System.NotImplementedException();
        }

        public TDriverOptions CreateOptions<TDriverOptions>(TDriverOptions driverOptions) where TDriverOptions : new()
        {
            throw new System.NotImplementedException();
        }

        public TDriverService CreateService<TDriverService>(TDriverService driverOptions)
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder EnableHeadlessMode()
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder HideCommandPrompt()
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder Reset()
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder SetBrowserVersion(string browserVersion)
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder SetPathToBrowserBinary(string pathToBinary)
        {
            throw new System.NotImplementedException();
        }

        public DriverBuilder SetPlatformName(string platformName)
        {
            throw new System.NotImplementedException();
        }
    }
}