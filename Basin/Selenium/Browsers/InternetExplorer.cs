using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Basin.Selenium.Browsers
{
    public class InternetExplorer
    {
        public readonly IWebDriver Current;

        public InternetExplorer(InternetExplorerOptions opts = null)
        {
            var options = opts ?? new InternetExplorerOptions();
            var service = InternetExplorerDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);

            service.HideCommandPromptWindow = true;

            Current = new InternetExplorerDriver(service, options);
        }
    }
}