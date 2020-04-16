using Basin.Config.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Basin
{
    public partial class Basin
    {
        [JsonProperty("CurrentSite")] public string CurrentSite { get; set; }

        [JsonProperty("Sites")] public List<SiteConfig> Sites { get; set; }

        [JsonProperty("Driver")] public DriverConfig Driver { get; set; }

        [JsonProperty("Logins")] public List<LoginConfig> Logins { get; set; }
    }

    public class DriverConfig : IDriverConfig
    {
        [JsonProperty("Timeout")] public int Timeout { get; set; }

        [JsonProperty("Browser")] public string Browser { get; set; }
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

    public partial class Basin
    {
        public static Basin FromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<Basin>(json, Converter.Settings);
        }

        public SiteConfig GetSite(string name)
        {
            return Sites.Find(site => site.Name == name);
        }

        public LoginConfig GetLogin(string role)
        {
            return Logins.Find(login => login.Role == role);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Basin self)
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