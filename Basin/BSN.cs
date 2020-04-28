using System;
using System.Text.RegularExpressions;
using Basin.Config;

namespace Basin
{
    public static class BSN
    {
        private static string _driverPath;
        
        private static Configuration _config;

        public static string DriverPath => _driverPath ?? AppDomain.CurrentDomain.BaseDirectory;
        
        public static Configuration Config => _config ?? throw new NullReferenceException("Config is null. Call SetConfig() first.");
        
        public static void SetConfig(string configPath)
        {
            _config = Configuration.FromJson(configPath);
            _driverPath = Config.Driver.PathToDrivers;
        }
    }
}