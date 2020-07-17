using System.Linq;
using System;
using System.Collections.Generic;
using Basin.Config.Interfaces;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers.Mappers
{
    public class InternetExplorerOptionsMapper : BrowserOptionsMapper<InternetExplorerOptions>
    {
        private readonly IBrowserConfig _config;

        public InternetExplorerOptionsMapper() : base(new InternetExplorerOptions())
        {
        }

        public InternetExplorerOptionsMapper(IBrowserConfig config) : base(new InternetExplorerOptions())
        {
            _config = config;
            PathToBrowserBinary = _config.PathToBrowserExecutable;
            BrowserVersion = _config.Version;
            PlatformName = _config.PlatformName;
            Arguments = _config.Arguments;
            EnableHeadlessMode = _config.Headless;
        }

        public override string PathToBrowserBinary
        {
            set => throw new NotSupportedException("InternetExplorerOptions() does not support setting the path the browser binary.");
        }

        public override string BrowserVersion
        {
            set => Options.BrowserVersion = value;
        }

        public override string PlatformName
        {
            set => Options.PlatformName = value;
        }

        public override IEnumerable<string> Arguments
        {
            set
            {
                Options.ForceCreateProcessApi = true;
                Options.BrowserCommandLineArguments = string.Join(" ", value.ToArray());
            }
        }

        public override bool EnableHeadlessMode
        {
            set
            {
                if (value) throw new NotSupportedException("Internet Explorer does not support headless execution.");
            }
        }
    }
}