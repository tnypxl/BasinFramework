using System;
using OpenQA.Selenium;

namespace Basin.Core.Browsers.Interfaces
{
    public interface IBrowser
    {
        IWebDriver Driver { get; set; }

        void CreateDriver(Uri host);
    }
}