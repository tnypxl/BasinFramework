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
        /// Locate an element by string selector. Only CSS/XPath strings are supported.
        /// Under the hood it intelligently uses the correct <see cref="By"/> method and returns an <see cref="Element"/>.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns><see cref="Element"/></returns>
        Element Locate(string selector);
        
        /// <inheritdoc cref="Locate(string)"/>
        /// <summary>
        /// Locate an element using <see cref="By"/> methods.
        /// </summary>
        /// <param name="by"></param>
        /// <returns><see cref="Element"/></returns>
        Element Locate(By by);
        
        /// <summary>
        /// Locates an element inside another element using string selectors.
        /// <seealso cref="Locate(string)"/>
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="parentSelector"></param>
        /// <returns></returns>
        Element LocateInside(string selector, string parentSelector);
        
        /// <summary>
        /// Locates an element inside another element using <see cref="By"/> methods.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="parentBy"></param>
        /// <returns></returns>
        Element LocateInside(By by, By parentBy);
        
        /// <summary>
        /// Locates multiple elements by a given string selector. See <seealso cref="Locate(string)"/>.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        Elements LocateAll(string selector);
        
        /// <summary>
        /// Locates multiple elements using <see cref="By"/> methods.
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        Elements LocateAll(By by);
        
        /// <summary>
        /// Locates multiple elements inside another element using string selectors.
        /// <seealso cref="LocateInside(string, string)"/>
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="parentSelector"></param>
        /// <returns></returns>
        Elements LocateAllInside(string selector, string parentSelector);
        
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