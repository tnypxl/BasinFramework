using Basin.Config;
using Basin.Config.Interfaces;
using Config.Net;

namespace Basin
{
    public static class Basin
    {
        public static CurrentConfig Config;

        public static ConfigurationBuilder<IConfig> GetConfig => new ConfigurationBuilder<IConfig>();

        public static void SetConfig(string configPath) => Config = new CurrentConfig(GetConfig.UseJsonFile(configPath).Build());
    }
}