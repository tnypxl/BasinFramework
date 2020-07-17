using Basin.Config.Interfaces;
using OpenQA.Selenium;

namespace Basin.Core.Browsers.Mappers
{
    public abstract class BrowserServiceMapper<TDriverService>
    {
        public abstract string PathToDriverBinary { get; set; }

        public TDriverService Service { get; set; }
    }
}