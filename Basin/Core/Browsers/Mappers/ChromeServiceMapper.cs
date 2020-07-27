using System;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Chrome;

namespace Basin.Core.Browsers.Mappers
{
    public class ChromeServiceMapper : DriverServiceMap<ChromeDriverService>
    {
        public override string PathToDriverBinary { get; set; }

        public ChromeServiceMapper(IBrowserConfig config)
        {
            PathToDriverBinary = config.PathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        public ChromeServiceMapper(string pathToDriverBinary = null)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary = null)
        {
            Service = ChromeDriverService.CreateDefaultService(pathToDriverBinary ?? AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}