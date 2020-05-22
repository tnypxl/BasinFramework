using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Basin.Selenium.Interfaces
{
    /// <summary>
    ///     Builder interface for configuring
    /// </summary>
    public interface IDriverBuilder
    {
        /// <summary>
        ///     Method to returns a newly created <seealso cref="IWebDriver" /> instance
        /// </summary>
        IWebDriver GetDriver { get; }

        /// <summary>
        ///     Method to create driver service.
        ///     <example>
        ///         <code>
        /// private FirefoxDriverService _driverService;
        /// 
        /// public void CreateService()
        /// {
        ///     _driverService = FirefoxDriverService.CreateDefaultService("path/to/driver/binary")
        /// }
        /// </code>
        ///     </example>
        /// </summary>
        void CreateService();

        /// <summary>
        ///     Method to create driver options
        ///     <example>
        ///         <code>
        /// private FirefoxOptions _driverOptions;
        /// 
        /// public void CreateOptions()
        /// {
        ///     _driverOptions = new FirefoxOptions();
        /// }
        /// </code>
        ///     </example>
        /// </summary>
        void CreateOptions();
        
        /// <summary>
        ///     Method to return a newly created <seealso cref="RemoteWebDriver" /> instance
        /// </summary>
        /// <param name="uri"></param>
        IWebDriver GetRemoteDriver(Uri uri);
    }

    public interface IChromeBuilder : IDriverBuilder
    {
        /// <summary>
        ///     Gets ChromeDriverService object.
        ///     Requires calling <seealso cref="IDriverBuilder.CreateOptions()" /> first.
        /// </summary>
        ChromeDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="ChromeOptions" />.
        ///     Requires calling <seealso cref="IDriverBuilder.CreateService()" /> first.
        /// </summary>
        ChromeOptions DriverOptions { get; }
    }

    public interface IFirefoxBuilder : IDriverBuilder
    {
        /// <summary>
        ///     Gets <see cref="FirefoxDriverService" /> object.
        ///     Requires calling <seealso cref="IDriverBuilder.CreateService()" /> first.
        /// </summary>
        FirefoxDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="FirefoxOptions" />.
        ///     Requires calling <seealso cref="IDriverBuilder.CreateOptions()" /> first.
        /// </summary>
        FirefoxOptions DriverOptions { get; }
    }

    public interface IInternetExplorerBuilder : IDriverBuilder
    {
        /// <summary>
        ///     Gets <see cref="InternetExplorerDriverService" /> object.
        ///     Requires calling <seealso cref="IDriverBuilder.CreateService()" /> first.
        /// </summary>
        InternetExplorerDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="InternetExplorerOptions" />.
        ///     Requires calling <seealso cref="IDriverBuilder.CreateOptions()" /> first.
        /// </summary>
        InternetExplorerOptions DriverOptions { get; }
    }
}