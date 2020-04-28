using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Basin.Selenium.Builders
{
    public class InternetExplorerBuilder : IDriverBuilder
    {
        private InternetExplorerDriverService _service;
        private InternetExplorerOptions _options;
        
        public void CreateService(object customDriverService = null)
        {
            _service = (InternetExplorerDriverService) customDriverService ?? InternetExplorerDriverService.CreateDefaultService(BSN.DriverPath);
        }

        public void CreateOptions(object customDriverOptions = null)
        {
            _options = (InternetExplorerOptions) customDriverOptions ?? new InternetExplorerOptions();
        }

        public IWebDriver GetDriver()
        {
            return new InternetExplorerDriver(_service, _options);
        }
    }
}