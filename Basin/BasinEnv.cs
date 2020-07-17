using System;
using Basin.Config;
using Basin.Config.Interfaces;
using Config.Net;

namespace Basin
{
    public static class BasinEnv
    {
        private static CurrentConfig _config;

        [ThreadStatic] public static ISiteConfig Site;

        [ThreadStatic] public static IBrowserConfig Browser;

        [ThreadStatic] public static ILoginConfig Login;

        public static ConfigurationBuilder<IConfig> GetConfig => new ConfigurationBuilder<IConfig>();

        public static void SetConfig(string configPath)
        {
            _config = new CurrentConfig(GetConfig.UseJsonFile(configPath).Build());
            Site = _config.Site;
            Browser = _config.Browser;

            if (_config.Login == null) return;

            Login = _config.Login;
        }

        public static void UseBrowser(string browserId) => Browser = _config.SetBrowserConfig(browserId).Browser;

        public static void UseSite(string siteId) => Site = _config.SetSiteConfig(siteId).Site;

        public static void UseLogin(string usernameOrRole) => Login = _config.SetLoginConfig(usernameOrRole).Login;
    }
}