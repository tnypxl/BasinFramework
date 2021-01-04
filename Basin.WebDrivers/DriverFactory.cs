using OpenQA.Selenium;
using Basin.WebDrivers.Interfaces;

namespace Basin.WebDrivers
{
    public static class DriverFactory
    {
        public static IWebDriver Instance;

        // public static IWebDriver
        public static IWebDriver Create(string driverType) => driverType switch
        {
            "chrome" => new ChromeBuilder()
                .CreateService()
                .CreateOptions()
                .Build(),
            "firefox" => new FirefoxBuilder()
                .CreateService()
                .CreateOptions()
                .Build(),
            "firefox" => new InternetExplorerBuilder()
                .CreateService()
                .CreateOptions()
                .Build(),
            _ => throw new NotSupportedException($"'{driverType}' is not a supported browser")
        };

        // public static BuildChromeDriver()

    }
}