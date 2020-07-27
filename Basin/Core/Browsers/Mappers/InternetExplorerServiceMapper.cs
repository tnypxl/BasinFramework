using System;
using Basin.Config.Interfaces;
using OpenQA.Selenium.IE;

namespace Basin.Core.Browsers.Mappers
{
    public class InternetExplorerServiceMapper : DriverServiceMap<InternetExplorerDriverService>
    {
        public override string PathToDriverBinary { get; set; }

        public InternetExplorerServiceMapper(string pathToDriverBinary = null)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        public InternetExplorerServiceMapper(IBrowserConfig config)
        {
            CreateService(config.PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary = null)
        {
            Service = InternetExplorerDriverService.CreateDefaultService(pathToDriverBinary ?? AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}