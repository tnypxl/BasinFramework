using System;
using System.IO;
using Basin.Config.Interfaces;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers.Mappers
{
    public class InternetExplorerServiceMapper : DriverServiceMap<InternetExplorerDriverService>
    {
        public override string PathToDriverBinary { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public override bool HideCommandPrompt { get; set; } = true;

        public InternetExplorerServiceMapper()
        {
            CreateService(PathToDriverBinary);
        }

        public InternetExplorerServiceMapper(string pathToDriverBinary)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        public InternetExplorerServiceMapper(IBrowserConfig config)
        {
            PathToDriverBinary = config.PathToDriverBinary ?? PathToDriverBinary;
            HideCommandPrompt = config.HideCommandPrompt;

            CreateService(PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary)
        {
            Service = InternetExplorerDriverService.CreateDefaultService(pathToDriverBinary);
            Service.HideCommandPromptWindow = HideCommandPrompt;
        }
    }
}