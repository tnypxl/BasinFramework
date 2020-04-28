using Basin.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Basin.Selenium.Builders
{
    public class FirefoxBuilder : IDriverBuilder
    {
        private FirefoxDriverService _service;
        private FirefoxOptions _options;
        
        public void CreateService(object customDriverService = null)
        {
            _service = (FirefoxDriverService) customDriverService ?? FirefoxDriverService.CreateDefaultService(BSN.DriverPath);
        }

        public void CreateOptions(object customDriverOptions = null)
        {
            _options = (FirefoxOptions) customDriverOptions ?? new FirefoxOptions();
        }

        public IWebDriver GetDriver()
        {
            return new FirefoxDriver(_service, _options);
        }
    }

    public class DefaultFirefox
    {
        private readonly FirefoxBuilder _builder;
        public FirefoxBuilder Instance;
        public DefaultFirefox(FirefoxBuilder builder)
        {
            _builder = builder;
            builder.CreateService();
            builder.CreateOptions();
        }
     }
}