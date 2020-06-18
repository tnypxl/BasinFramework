using System;
using System.Linq;
using System.Text.RegularExpressions;
using Basin.Config.Interfaces;
using Config.Net;

namespace Basin
{
    public static class BSN
    {
        public static IConfig Config;

        public static ConfigurationBuilder<IConfig> CreateConfig => new ConfigurationBuilder<IConfig>();

        public static void SetConfig(string configPath)
        {
            Config = CreateConfig.UseJsonFile(configPath).Build();
            Config.Site = Config.Sites.First(site => site.Name == Config.Environment.Site);
            Config.Driver = Config.Drivers.First(driver => driver.Name == Config.Environment.Driver);
            Config.Driver.PathToDriver ??= AppDomain.CurrentDomain.BaseDirectory;

            if (string.IsNullOrEmpty(Config.Environment.Login)) return;

            Config.Login = Config.Logins.First(login => Regex.IsMatch(Config.Environment.Login, $"{login.Role}|{login.Username}"));
        }
    }
}