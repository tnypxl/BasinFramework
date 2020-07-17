using System.Collections.Generic;
using Basin.Config.Interfaces;

namespace Basin.Core.Browsers.Mappers
{
    public abstract class BrowserOptionsMapper<TDriverOptions> where TDriverOptions : new()
    {
        protected BrowserOptionsMapper(TDriverOptions options)
        {
            Options = options;
        }

        public abstract string PathToBrowserBinary { set; }

        public abstract string BrowserVersion { set; }

        public abstract string PlatformName { set; }

        public abstract IEnumerable<string> Arguments { set; }

        public abstract bool EnableHeadlessMode { set; }

        public TDriverOptions Options { get; }
    }
}