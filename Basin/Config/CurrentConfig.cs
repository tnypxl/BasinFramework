using System;
using System.Linq;
using System.Text.RegularExpressions;
using Basin.Config.Interfaces;

namespace Basin.Config
{
    public class CurrentConfig : ICurrentConfig
    {
        private static IConfig _config;

        public IDriverConfig Driver { get; set; }
        public ISiteConfig Site { get; set; }
        public ILoginConfig Login { get; set; }

        public CurrentConfig(IConfig config)
        {
            _config = config;

            SetSiteConfig();
            SetDriverConfig();
            SetLoginConfig();

            Driver.PathToDriver ??= AppDomain.CurrentDomain.BaseDirectory;
        }

        public void SetSiteConfig() => Site = _config.Sites.First(site => site.Name == _config.Environment.Site);

        public void SetDriverConfig() => Driver = _config.Drivers.First(driver => driver.Name == _config.Environment.Driver);

        public void SetLoginConfig()
        {
            if (string.IsNullOrEmpty(_config.Environment.Login)) return;

            Login = _config.Logins.First(login => Regex.IsMatch(_config.Environment.Login, $"{login.Role}|{login.Username}"));
        }
    }
}