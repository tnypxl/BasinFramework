using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Basin.Selenium.Builders
{
    public class ChromeBuilder : IDriverBuilder
    {
        private ChromeDriverService _service;
        private ChromeOptions _options;
        
        public void CreateService(object customDriverService = null)
        {
            _service = (ChromeDriverService) customDriverService ?? ChromeDriverService.CreateDefaultService(BSN.DriverPath);
        }

        public void CreateOptions(object customDriverOptions = null)
        {
            _options = (ChromeOptions) customDriverOptions ?? new ChromeOptions();
        }

        public IWebDriver GetDriver()
        {
            return new ChromeDriver(_service, _options);
        }
    }
}