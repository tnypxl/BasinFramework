using System;
using System.Collections.Generic;
using System.ComponentModel;
using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IDriverConfig
    {
        string Name { get; set; }

        [Option(DefaultValue = "chrome")]
        string BrowserName { get; set; }

        [Option(DefaultValue = 10)]
        int Timeout { get; set; }

        string PlatformName { get; set; }

        string BrowserVersion { get; set; }

        IEnumerable<string> Arguments { get; }

        bool Headless { get; set; }

        string PathToDriver { get; set; }

        Uri Host { get; set; }
    }

    public class DriverConfig : IDriverConfig
    {
        public string Name { get; set; }
        public string BrowserName { get; set; }
        public int Timeout { get; set; }
        public string PlatformName { get; set; }
        public string BrowserVersion { get; set; }
        public IEnumerable<string> Arguments { get; set; }
        public bool Headless { get; set; }
        public string PathToDriver { get; set; }
        public Uri Host { get; set; }
    }
}