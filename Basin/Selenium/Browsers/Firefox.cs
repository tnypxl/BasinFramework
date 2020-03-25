using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Basin.Selenium.Browsers
{
    public class Firefox
    {
        public readonly IWebDriver Current;

        public Firefox(FirefoxOptions opts = null)
        {
            var options = opts ?? new FirefoxOptions();
            var service = FirefoxDriverService.CreateDefaultService();

            service.HideCommandPromptWindow = true;

            Current = new FirefoxDriver(service, options);
        }
    }
}