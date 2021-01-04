using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Basin.WebDrivers.Interfaces
{
    public class ChromeInstance : IDriverBuilder<ChromeOptions, ChromeDriverService>
    {
        public string PathToBrowserBinary { get; set; }
        
        public string BrowserVersion { get; set; }
        
        public string PlatformName { get; set; }
        
        public IEnumerable<string> Arguments { get; set; }
        
        public bool EnableHeadlessMode { get; set; }
        
        public bool AcceptsInsecureCerts { get; set; }
        
        public void SetCapabilities(Dictionary<string, object> value)
        {
            throw new System.NotImplementedException();
        }

        public ChromeOptions CreateOptions()
        {
            throw new System.NotImplementedException();
        }

        public ChromeOptions Options { get; set; }
        
        public ChromeDriverService CreateService()
        {
            throw new System.NotImplementedException();
        }

        public ChromeDriverService Service { get; set; }
        
        public IWebDriver Driver { get; set; }
    }
}