using System;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Chrome;

namespace Basin.Core.Browsers.Mappers
{
    public sealed class ChromeServiceMapper : DriverServiceMap<ChromeDriverService>
    {
        public override string PathToDriverBinary { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public override bool HideCommandPrompt { get; set; } = true;

        public ChromeServiceMapper()
        {
            CreateService(PathToDriverBinary);
        }

        public ChromeServiceMapper(IBrowserConfig config)
        {
            PathToDriverBinary = config.PathToDriverBinary ?? PathToDriverBinary;
            HideCommandPrompt = config.HideCommandPrompt;

            CreateService(PathToDriverBinary);
        }

        public ChromeServiceMapper(string pathToDriverBinary)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary)
        {
            Service = ChromeDriverService.CreateDefaultService(pathToDriverBinary);
            Service.HideCommandPromptWindow = HideCommandPrompt;
        }
    }
}
