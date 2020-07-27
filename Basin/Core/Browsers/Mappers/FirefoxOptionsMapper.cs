using System.Collections.Generic;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Firefox;

namespace Basin.Core.Browsers.Mappers
{
    public class FirefoxOptionsMapper : DriverOptionsMap<FirefoxOptions>
    {
        public FirefoxOptionsMapper()
        {
        }

        public FirefoxOptionsMapper(IBrowserConfig config)
        {
            PathToBrowserBinary = config.PathToBrowserExecutable;
            BrowserVersion = config.Version;
            PlatformName = config.PlatformName;
            Arguments = config.Arguments;
            EnableHeadlessMode = config.Headless;
            AcceptsInsecureCerts = config.AcceptsInsecureCerts;

            SetCapabilities(config.Capabilities);
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
            set
            {
                if (value == null) return;
                Options.AddArguments(value);
            }
        }

        public override bool AcceptsInsecureCerts
        {
            set => Options.AcceptInsecureCertificates = value;
        }

        public override bool EnableHeadlessMode
        {
            set
            {
                if (value) Options.AddArgument("-headless");
            }
        }

        public override void SetCapabilities(Dictionary<string, object> caps)
        {
            if (caps == null || caps.Count == 0) return;

            foreach (var cap in caps) Options.AddAdditionalCapability(cap.Key, cap.Value, true);
        }
    }
}