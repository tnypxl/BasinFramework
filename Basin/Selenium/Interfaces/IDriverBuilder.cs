using System;
using Microsoft.Edge.SeleniumTools;
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
        ///     Gets ChromeDriverService object.  <seealso cref="IDriverBuilder.CreateOptions()" />
        /// </summary>
        ChromeDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="ChromeOptions" />. <seealso cref="IDriverBuilder.CreateService()" />
        /// </summary>
        ChromeOptions DriverOptions { get; }
    }

    public interface IFirefoxBuilder : IDriverBuilder
    {
        /// <summary>
        ///     Gets <see cref="FirefoxDriverService" /> object. <seealso cref="IDriverBuilder.CreateService()" />
        /// </summary>
        FirefoxDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="FirefoxOptions" />. <seealso cref="IDriverBuilder.CreateOptions()" />
        /// </summary>
        FirefoxOptions DriverOptions { get; }
    }

    public interface IInternetExplorerBuilder : IDriverBuilder
    {
        /// <summary>
        ///     Gets <see cref="InternetExplorerDriverService" /> object. <seealso cref="IDriverBuilder.CreateService()" />
        /// </summary>
        InternetExplorerDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="InternetExplorerOptions" />. <seealso cref="IDriverBuilder.CreateOptions()" /> first.
        /// </summary>
        InternetExplorerOptions DriverOptions { get; }
    }

    public interface IEdgeBuilder : IDriverBuilder
    {
        /// <summary>
        ///     Gets <see cref="EdgeDriverService" /> object. <seealso cref="CreateService()" />
        ///     
        /// </summary>
         EdgeDriverService DriverService { get; }

        /// <summary>
        ///     Gets <see cref="EdgeOptions" /> object. <seealso cref="IDriverBuilder.CreateOptions()" />
        /// </summary>
        EdgeOptions DriverOptions { get; }
    }
}