using System.Linq;
using System;
using System.Collections.Generic;
using Basin.Config.Interfaces;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers.Mappers
{
    public class InternetExplorerOptionsMapper : DriverOptionsMap<InternetExplorerOptions>
    {
        public InternetExplorerOptionsMapper()
        {
        }

        public InternetExplorerOptionsMapper(IBrowserConfig config)
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

        public override bool AcceptsInsecureCerts
        {
            set => Options.AcceptInsecureCertificates = value;
        }

        public override bool EnableHeadlessMode
        {
            set
            {
                if (value) throw new NotSupportedException("Internet Explorer does not support headless execution.");
            }
        }

        public override void SetCapabilities(Dictionary<string, object> caps)
        {
            if (caps == null || caps.Count == 0) return;

            foreach (var cap in caps) Options.AddAdditionalCapability(cap.Key, cap.Value, true);
        }
    }
}