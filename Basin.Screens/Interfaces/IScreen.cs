using System.Collections.Generic;
using Basin.Screens.Interfaces;
using Basin.Selenium;

namespace Basin.Screens.Interfaces
{
    /// <summary>
    /// Implement #Map on derived classes.
    /// </summary>
    /// <typeparam name="TScreenMap"></typeparam>
    public interface IScreen<TScreenMap>
    {
        TScreenMap Map { get; }

    }
}