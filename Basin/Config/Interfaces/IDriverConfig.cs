using System;
using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IDriverConfig
    {
        string Name { get; set; }

        [Option(DefaultValue = "chrome")]
        string BrowserName { get; set; }

        [Option(DefaultValue = 30)]
        int Timeout { get; set; }

        string PlatformName { get; set; }

        string BrowserVersion { get; set; }

        string[] Arguments { get; set; }

        string PathToDriver { get; set; }

        Uri Host { get; set; }
    }
}