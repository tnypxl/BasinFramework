using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Basin.WebDrivers.Interfaces;

namespace Basin.WebDrivers
{

    public class ChromeOptionsMapper : IDriverOptionsMapper<ChromeOptions>
    {
    }

    public interface IDriverServiceMapper<out DriverService>
    {

    }

    public interface IDriverBuilder
    {
        DriverBuilder AddArguments(params string[] driverArgs);
        DriverBuilder AddCapabilities(Dictionary<string, object> caps);
        IWebDriver Build();
        TDriverOptions CreateOptions<TDriverOptions>(TDriverOptions driverOptions) where TDriverOptions : new();
        TDriverService CreateService<TDriverService>(TDriverService driverOptions);
        DriverBuilder EnableHeadlessMode();
        DriverBuilder HideCommandPrompt();
        DriverBuilder Reset();
        DriverBuilder SetBrowserVersion(string browserVersion);
        DriverBuilder SetPathToBrowserBinary(string pathToBinary);
        DriverBuilder SetPlatformName(string platformName);
    }

    public class DriverBuilder : IDriverBuilder
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