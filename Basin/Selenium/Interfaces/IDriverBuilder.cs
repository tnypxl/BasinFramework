using System.Runtime.InteropServices;
using OpenQA.Selenium;

namespace Basin.Selenium.Interfaces
{
    public interface IDriverBuilder
    {
        void CreateService([Optional] object customDriverService);

        void CreateOptions([Optional] object customDriverOptions);
        
        IWebDriver GetDriver();
    }
}