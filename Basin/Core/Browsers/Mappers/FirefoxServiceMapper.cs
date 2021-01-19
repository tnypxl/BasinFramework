using System;
using System.IO;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Firefox;

namespace Basin.Core.Browsers.Mappers
{
    public class FirefoxServiceMapper : DriverServiceMap<FirefoxDriverService>
    {
        public override string PathToDriverBinary { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public override bool HideCommandPrompt { get; set; } = true;

        public FirefoxServiceMapper()
        {
            CreateService(PathToDriverBinary);
        }

        public FirefoxServiceMapper(string pathToDriverBinary)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        public FirefoxServiceMapper(IBrowserConfig config)
        {
            PathToDriverBinary ??= config.PathToDriverBinary;
            HideCommandPrompt = config.HideCommandPrompt;

            CreateService(PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary)
        {
            Service = FirefoxDriverService.CreateDefaultService(pathToDriverBinary);
            Service.HideCommandPromptWindow = HideCommandPrompt;
        }
    }
}
