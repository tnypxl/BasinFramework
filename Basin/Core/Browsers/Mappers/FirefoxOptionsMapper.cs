using System.Collections.Generic;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Firefox;

namespace Basin.Core.Browsers.Mappers
{
    public class FirefoxOptionsMapper : BrowserOptionsMapper<FirefoxOptions>
    {
        private readonly IBrowserConfig _config;

        public FirefoxOptionsMapper(IBrowserConfig config) : base(new FirefoxOptions())
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
            set => Options.BrowserExecutableLocation = value;
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
            set => Options.AddArguments(value);
        }

        public override bool EnableHeadlessMode
        {
            set
            {
                if (value)
                    Options.AddArgument("-headless");
            }
        }
    }
}