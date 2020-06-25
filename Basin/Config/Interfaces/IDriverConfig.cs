using System;
using System.Collections.Generic;
using Config.Net;
using OpenQA.Selenium;

namespace Basin.Config.Interfaces
{
    public interface IDriverConfig
    {
        [Option(DefaultValue = "Local Chrome")]
        string Name { get; set; }

        [Option(DefaultValue = "chrome")]
        string BrowserName { get; set; }

        [Option(DefaultValue = 10)]
        int Timeout { get; set; }

        string PlatformName { get; set; }

        string BrowserVersion { get; set; }

        IEnumerable<string> Arguments { get; }

        bool Headless { get; set; }

        string PageLoadStrategy { get; set; }

        string PathToDriver { get; set; }

        Uri Host { get; set; }
    }

    public class DriverConfig : IDriverConfig
    {
        public static Dictionary<string, PageLoadStrategy> PageLoadStrategies { get; } = new Dictionary<string, PageLoadStrategy>()
        {
            {"default", OpenQA.Selenium.PageLoadStrategy.Default},
            {"normal", OpenQA.Selenium.PageLoadStrategy.Normal},
            {"eager", OpenQA.Selenium.PageLoadStrategy.Eager},
            {"none", OpenQA.Selenium.PageLoadStrategy.None},
        };

        public string Name { get; set; }

        public string BrowserName { get; set; }

        public int Timeout { get; set; }

        public string PlatformName { get; set; }

        public string BrowserVersion { get; set; }

        public IEnumerable<string> Arguments { get; set; }

        public bool Headless { get; set; }

        public string PageLoadStrategy { get; set; }

        public string PathToDriver { get; set; }
        public Uri Host { get; set; }
    }
}