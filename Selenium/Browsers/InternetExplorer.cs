using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Selenium.Browsers
{
    public class InternetExplorer
    {
        public readonly IWebDriver Current;
        
        public InternetExplorer(InternetExplorerOptions opts = null)
        {
            var options = opts ?? new InternetExplorerOptions();
            var service = InternetExplorerDriverService.CreateDefaultService();
            
            service.HideCommandPromptWindow = true;

            Current = new InternetExplorerDriver(service, options);
        }
    }
}