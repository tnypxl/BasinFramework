using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Screens.Interfaces
{
    /// <summary>
    ///     Interface for implementing methods from Basin.Selenium.Driver.
    /// </summary>
    public interface IScreenMapBase
    {
        Element Locate(By by);

        Element Locate(string css);

        Elements LocateAll(By by);
    }

    /// <summary>
    ///     Interface for page/screen map classes.
    /// </summary>
    public interface IScreenMap
    {
        /// <summary>
        ///     Adds a common method for defining the root/containing element in a map class.
        /// </summary>
        Element Container { get; }
    }

    /// <inheritdoc cref="IScreenMap" />
    public interface IPageMap : IScreenMap
    {
    }

    /// <inheritdoc cref="IScreenMapBase" />
    public interface IPageMapBase : IScreenMapBase
    {
    }
}