using System.Collections.Generic;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Chrome;

namespace Basin.Core.Browsers.Mappers
{
    public class ChromeOptionsMapper : DriverOptionsMap<ChromeOptions>
    {
        public ChromeOptionsMapper()
        {
        }

        public ChromeOptionsMapper(IBrowserConfig config)
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
            set => Options.BinaryLocation = value;
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

        public override bool AcceptsInsecureCerts
        {
            set => Options.AcceptInsecureCertificates = value;
        }

        public override bool EnableHeadlessMode
        {
            set
            {
                if (value)
                    Options.AddArguments("--headless", "--disable-gpu");
            }
        }

        public override void SetCapabilities(Dictionary<string, object> caps)
        {
            if (caps.Count > 0)
                foreach (var cap in caps) Options.AddAdditionalCapability(cap.Key, cap.Value, true);
        }
    }
}