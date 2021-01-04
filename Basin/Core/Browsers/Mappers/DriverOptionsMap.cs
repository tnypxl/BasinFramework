using System.Collections.Generic;
using Basin.Config.Interfaces;

namespace Basin.Core.Browsers.Mappers
{
    public abstract class DriverOptionsMap<out DriverOptions>
    {
        protected DriverOptionsMap() => Options = new DriverOptions();

        public abstract string PathToBrowserBinary { set; }

        public abstract string BrowserVersion { set; }

        public abstract string PlatformName { set; }

        public abstract IEnumerable<string> Arguments { set; }

        public abstract bool EnableHeadlessMode { set; }

        public abstract bool AcceptsInsecureCerts { set; }

        public abstract void SetCapabilities(Dictionary<string, object> value);

        public DriverOptions Options { get; }
    }
}