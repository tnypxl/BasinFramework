using System;
using System.Collections.Generic;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Chrome;

namespace Basin.Core.Browsers.Mappers
{
    public class ChromeOptionsMapper : BrowserOptionsMapper<ChromeOptions>
    {
        public ChromeOptionsMapper() : base(new ChromeOptions())
        {
        }

        public ChromeOptionsMapper(IBrowserConfig config) : base(new ChromeOptions())
        {
            PathToBrowserBinary = config.PathToBrowserExecutable;
            BrowserVersion = config.Version;
            PlatformName = config.PlatformName;
            Arguments = config.Arguments;
            EnableHeadlessMode = config.Headless;
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

        public override bool EnableHeadlessMode
        {
            set
            {
                if (value)
                    Options.AddArguments("--headless", "--disable-gpu");
            }
        }
    }
}