using System.Collections.Generic;
using Basin.Core.Browsers.Interfaces;
using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IConfig
    {
        [Option(Alias = "Environment")]
        IEnvironmentConfig Environment { get; }

        [Option(Alias = "Browsers")]
        IEnumerable<IBrowserConfig> Browsers { get; }

        [Option(Alias = "Sites")]
        IEnumerable<ISiteConfig> Sites { get; }

        [Option(Alias = "Logins")]
        IEnumerable<ILoginConfig> Logins { get; }
    }

    public interface ICurrentConfig
    {
        IBrowserConfig Browser { get; set; }

        ISiteConfig Site { get; set; }

        ILoginConfig Login { get; set; }
    }
}