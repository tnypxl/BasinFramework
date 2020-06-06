using Basin.Selenium;

namespace Basin.Pages.Interfaces
{
    public interface IPageBase
    {
        /// <summary>
        /// Property for implementing an instance of the <see cref="Wait"/> class
        /// </summary>
        Wait Wait { get; }

        /// <summary>
        /// Instantiates a page object class for use with other fluent page object classes
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns><see cref="TPage"/></returns>
        TPage On<TPage>() where TPage : new();
    }
}