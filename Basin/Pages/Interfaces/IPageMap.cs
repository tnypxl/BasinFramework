using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Pages.Interfaces
{
    /// <summary>
    /// Implements Driver methods in base page map classes.
    /// </summary>
    public interface IPageMap
    {
        /// <summary>
        /// Locate an element using <see cref="By"/> methods.
        /// </summary>
        /// <param name="by"></param>
        /// <returns><see cref="Element"/></returns>
        Element Locate(By by);
                
        /// <summary>
        /// Locates an element inside another element using <see cref="By"/> methods.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="parentBy"></param>
        /// <returns></returns>
        Element LocateInside(By by, By parentBy);
        
        /// <summary>
        /// Locates multiple elements using <see cref="By"/> methods.
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        Elements LocateAll(By by);
        
        /// <summary>
        /// Locates multiple elements inside another element using string selectors.
        /// <seealso cref="LocateInside(By, By)"/>
        /// </summary>
        /// <param name="by"></param>
        /// <param name="parentBy"></param>
        /// <returns></returns>
        Elements LocateAllInside(By by, By parentBy);
    }
}