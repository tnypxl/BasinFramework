namespace Basin.Config.Interfaces
{
    public interface ISiteConfig
    {
        string Name { get; set; }
        string Url { get; set; }
    }

    public class SiteConfig : ISiteConfig
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}