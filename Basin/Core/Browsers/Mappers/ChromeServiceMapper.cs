using System;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Chromium;

namespace Basin.Core.Browsers.Mappers
{
    public class ChromiumServiceMapper : DriverServiceMap<ChromiumDriverService>
    {
        public override string PathToDriverBinary { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public override bool HideCommandPrompt { get; set; } = true;

        public ChromiumServiceMapper()
        {
            CreateService(PathToDriverBinary);
        }

        public ChromiumServiceMapper(IBrowserConfig config)
        {
            PathToDriverBinary = config.PathToDriverBinary ?? PathToDriverBinary;
            HideCommandPrompt = config.HideCommandPrompt;

            CreateService(PathToDriverBinary);
        }

        public ChromiumServiceMapper(string pathToDriverBinary)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary)
        {
            Service = ChromiumDriverService;
            Service.HideCommandPromptWindow = HideCommandPrompt;
        }
    }
}
