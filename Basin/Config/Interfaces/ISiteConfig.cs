namespace Basin.Config.Interfaces
{
    public interface ISiteConfig
    {
        string Id { get; set; }

        string Url { get; set; }
    }

    public class SiteConfig : ISiteConfig
    {
        public string Id { get; set; }

        public string Url { get; set; }
    }
}