using System.Collections.Generic;
using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IConfig
    {
        IDriverConfig Driver { get; set; }

        ISiteConfig Site { get; set; }

        ILoginConfig Login { get; set; }

        [Option(Alias = "Environment")]
        IEnvironmentConfig Environment { get; }

        [Option(Alias = "Drivers")]
        IEnumerable<IDriverConfig> Drivers { get; }

        [Option(Alias = "Sites")]
        IEnumerable<ISiteConfig> Sites { get; }

        [Option(Alias = "Logins")]
        IEnumerable<ILoginConfig> Logins { get; }
    }
}