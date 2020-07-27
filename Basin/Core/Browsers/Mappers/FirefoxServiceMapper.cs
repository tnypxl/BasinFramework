using System;
using Basin.Config.Interfaces;
using OpenQA.Selenium.Firefox;

namespace Basin.Core.Browsers.Mappers
{
    public class FirefoxServiceMapper : DriverServiceMap<FirefoxDriverService>
    {
        public override string PathToDriverBinary { get; set; }

        public FirefoxServiceMapper(string pathToDriverBinary = null)
        {
            PathToDriverBinary = pathToDriverBinary;

            CreateService(PathToDriverBinary);
        }

        public FirefoxServiceMapper(IBrowserConfig config)
        {
            CreateService(config.PathToDriverBinary);
        }

        private void CreateService(string pathToDriverBinary = null)
        {
            Service = FirefoxDriverService.CreateDefaultService(pathToDriverBinary ?? AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}