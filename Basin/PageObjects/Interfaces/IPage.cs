namespace Basin.PageObjects.Interfaces
{
    /// <summary>
    /// Interface for defining page object classes with element maps.
    /// </summary>
    public interface IPage
    {
    }

    public interface IPage<in TPageMap>
    {
        /// <summary>
        /// Property to store page element map objects
        /// </summary>
        TPageMap Map { set; }
    }
}