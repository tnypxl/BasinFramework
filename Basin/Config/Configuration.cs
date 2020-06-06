using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Basin.Config.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Basin.Config
{
    public partial class Configuration
    {
        [JsonProperty("DefaultSite")] public string DefaultSite { get; set; }

        [JsonProperty("Sites")] public List<SiteConfig> Sites { get; set; }

        [JsonProperty("Driver")] public DriverConfig Driver { get; set; }

        [JsonProperty("Logins")] public List<LoginConfig> Logins { get; set; }
    }

    public class DriverConfig : IDriverConfig
    {
        [JsonProperty("Timeout")] public int Timeout { get; set; }

        [JsonProperty("Browser")] public string Browser { get; set; }

        [JsonProperty("PathToDrivers")] public string PathToDrivers { get; set; }

        [JsonProperty("Host")] public Uri Host { get; set; }
    }

    public class LoginConfig : ILoginConfig
    {
        [JsonProperty("Role")] public string Role { get; set; }

        [JsonProperty("Username")] public string Username { get; set; }

        [JsonProperty("Password")] public string Password { get; set; }

        [JsonProperty("Token")] public string Token { get; set; }
    }

    public class SiteConfig : ISiteConfig
    {
        [JsonProperty("Name")] public string Name { get; set; }

        [JsonProperty("Url")] public string Url { get; set; }
    }

    public partial class Configuration
    {
        private static Configuration _config;
        public static Configuration FromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);

            _config = JsonConvert.DeserializeObject<Configuration>(json, Converter.Settings);

            return _config;
        }

        public SiteConfig Site => _config.Sites.Find(site => site.Name == _config.DefaultSite);

        public LoginConfig Login(string role)
        {
            return _config.Logins.Find(login => login.Role == role);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Configuration self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }
}