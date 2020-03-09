using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Browsers
{
    internal class Chrome
    {
        public readonly IWebDriver Current;
        
        public Chrome(ChromeOptions opts = null)
        {
            var options = opts ?? new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();
            
            service.HideCommandPromptWindow = true;

            Current = new ChromeDriver(service, options);
        }
    }
}