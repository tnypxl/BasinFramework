using Basin.Selenium;

namespace Basin.Screens.Interfaces
{
    /// <summary>
    /// Interface for defining page/screen object classes.
    /// </summary>
    /// <typeparam name="TScreenMap"></typeparam>
    public interface IScreen<out TScreenMap>
    {
        /// <summary>
        /// Implements accessor for an IScreenMap class object.
        /// </summary>
        TScreenMap Map { get; }
    }
    
    
    /// <inheritdoc cref="IScreen{TScreenMap}"/>
    /// <typeparam name="TPageMap"></typeparam>
    public interface IPage<out TPageMap> : IScreen<TPageMap> { }
    
    /// <inheritdoc cref="IScreen{TScreenMap}"/>
    /// <typeparam name="TScreenComponentMap"></typeparam>
    public interface IScreenComponent<out TScreenComponentMap> : IScreen<TScreenComponentMap> {}
    
    /// <inheritdoc cref="IScreen{TScreenMap}"/>
    /// <typeparam name="TPageComponentMap"></typeparam>
    public interface IPageComponent<out TPageComponentMap> : IScreen<TPageComponentMap> {}

    //
    public interface IPageBase
    {
        /// <summary>
        /// Interface for implementing methods from Basin.Selenium.Driver.
        /// </summary>
        Wait Wait { get; }
    }
}