using System.Collections.Generic;
using OpenQA.Selenium;

namespace Basin.WebDrivers.Interfaces
{
    public interface IDriverBuilder<TDriverOptions, TDriverService>
    {
        string PathToBrowserBinary { set; }

        string BrowserVersion { set; }

        string PlatformName { set; }

        IEnumerable<string> Arguments { set; }

        bool EnableHeadlessMode { set; }

        bool AcceptsInsecureCerts { set; }

        void SetCapabilities(Dictionary<string, object> value);

        void HideCommandPrompt();

        TDriverOptions CreateOptions();

        TDriverOptions Options { get; set; }

        TDriverService CreateService();
        
        TDriverService Service { get; set; }
        
        IWebDriver Driver { get; set; }
    }
}