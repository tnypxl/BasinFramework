using System;
using System.Linq;
using System.Text.RegularExpressions;
using Basin.Config.Interfaces;
using Basin.Core.Browsers.Interfaces;

namespace Basin.Config
{
    public class CurrentConfig : ICurrentConfig
    {
        private static IConfig _config;

        public IBrowserConfig Browser { get; set; }
        public ISiteConfig Site { get; set; }
        public ILoginConfig Login { get; set; }

        public CurrentConfig(IConfig config)
        {
            _config = config;

            SetSiteConfig();
            SetBrowserConfig();
            SetLoginConfig();
        }

        public void SetSiteConfig() => Site = _config.Sites.First(site => site.Id == _config.Environment.Site);

        public void SetBrowserConfig() => Browser = _config.Browsers.First(browser => browser.Id == _config.Environment.Browser);

        public void SetLoginConfig()
        {
            if (string.IsNullOrEmpty(_config.Environment.Login)) return;

            Login = _config.Logins.First(login => Regex.IsMatch(_config.Environment.Login, $"{login.Role}|{login.Username}"));
        }
    }
}