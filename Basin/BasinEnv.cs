using Basin.Config;
using Basin.Config.Interfaces;
using Config.Net;

namespace Basin
{
    public static class BasinEnv
    {
        private static CurrentConfig _config;

        public static ISiteConfig Site;

        public static IBrowserConfig Browser;

        public static ILoginConfig Login;

        public static ConfigurationBuilder<IConfig> GetConfig => new ConfigurationBuilder<IConfig>();

        public static void SetConfig(string configPath)
        {
            _config = new CurrentConfig(GetConfig.UseJsonFile(configPath).Build());
            Site = _config.Site;
            Browser = _config.Browser;

            if (_config.Login == null) return;

            Login = _config.Login;
        }
    }
}