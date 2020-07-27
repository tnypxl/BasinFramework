using System;
using Basin.Config;
using Basin.Config.Interfaces;
using Config.Net;
using Basin.PageObjects.Interfaces;
using Basin.Config.Extensions;

namespace Basin
{
    public static class BasinEnv
    {
        [ThreadStatic] private static CurrentConfig _config;

        [ThreadStatic] public static ISiteConfig Site;

        [ThreadStatic] public static IBrowserConfig Browser;

        [ThreadStatic] public static ILoginConfig Login;

        [ThreadStatic] public static IPageCollection Pages;

        public static ConfigurationBuilder<IConfig> GetConfig => new ConfigurationBuilder<IConfig>();

        public static void SetConfig(string configPath)
        {
            _config = new CurrentConfig(GetConfig.UseJsonFile(configPath)
                                                 .UseTypeParser(new DictionaryParser())
                                                 .Build());
            Site = _config.Site;
            Browser = _config.Browser;
            Pages = _config.Pages;

            if (_config.Login == null) return;

            Login = _config.Login;
        }

        public static void UseBrowser(string browserId) => Browser = _config.SetBrowserConfig(browserId).Browser;

        public static void UseBrowser(IBrowserConfig browserConfig) => Browser = browserConfig;

        public static void UseSite(string siteId) => Site = _config.SetSiteConfig(siteId).Site;

        public static void UseSite(ISiteConfig siteConfig) => Site = siteConfig;

        public static void UseLogin(string usernameOrRole) => Login = _config.SetLoginConfig(usernameOrRole).Login;

        public static void UseLogin(ILoginConfig loginConfig) => Login = loginConfig;
    }
}