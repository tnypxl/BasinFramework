using System;
using System.Linq;
using System.Text.RegularExpressions;
using Basin.Config.Interfaces;
using Basin.PageObjects;
using Basin.PageObjects.Interfaces;

namespace Basin.Config
{
    public class CurrentConfig : ICurrentConfig
    {
        private static IConfig _config;

        public IBrowserConfig Browser { get; set; }

        public ISiteConfig Site { get; set; }

        public ILoginConfig Login { get; set; }

        public IPageCollection Pages { get; }

        public CurrentConfig(IConfig config)
        {
            _config = config;

            SetSiteConfig(_config.Environment.Site);
            SetBrowserConfig(_config.Environment.Browser);
            SetLoginConfig(_config.Environment.Login);
            Pages = new PageCollection();
        }

        public CurrentConfig SetSiteConfig(string siteId)
        {
            if (string.IsNullOrEmpty(siteId))
                throw new ArgumentNullException(nameof(siteId));

            Site = _config.Sites.First(site => siteId == site.Id);

            return this;
        }

        public CurrentConfig SetBrowserConfig(string browserId)
        {
            if (string.IsNullOrEmpty(browserId))
                throw new ArgumentNullException(nameof(browserId));

            Browser = _config.Browsers.First(browser => browserId == browser.Id);

            return this;
        }

        public CurrentConfig SetLoginConfig(string usernameOrRole)
        {
            if (string.IsNullOrEmpty(usernameOrRole)) return this;

            Login = _config.Logins.First(login => Regex.IsMatch(usernameOrRole, $"{login.Role}|{login.Username}"));

            return this;
        }
    }
}
