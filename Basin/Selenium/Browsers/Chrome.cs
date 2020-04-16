using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Basin.Selenium.Browsers
{
    internal class Chrome
    {
        public readonly IWebDriver Current;

        public Chrome(ChromeOptions opts = null)
        {
            var options = opts ?? new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);

            service.HideCommandPromptWindow = true;

            Current = new ChromeDriver(service, options);
        }
    }
}