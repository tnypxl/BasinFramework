using System.Collections.Generic;
using Basin.Config.Interfaces;

namespace Basin.Core.Browsers.Mappers
{
    public abstract class DriverOptionsMap<TDriverOptions> where TDriverOptions : new()
    {
        protected DriverOptionsMap() => Options = new TDriverOptions();

        public abstract string PathToBrowserBinary { set; }

        public abstract string BrowserVersion { set; }

        public abstract string PlatformName { set; }

        public abstract IEnumerable<string> Arguments { set; }

        public abstract bool EnableHeadlessMode { set; }

        public abstract bool AcceptsInsecureCerts { set; }

        public abstract void SetCapabilities(Dictionary<string, object> value);

        public TDriverOptions Options { get; }
    }
}