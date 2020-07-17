using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IEnvironmentConfig
    {
        string Site { get; set; }

        string Login { get; set; }

        string Browser { get; set; }
    }

    public class EnvironmentConfig : IEnvironmentConfig
    {
        public string Site { get; set; }

        public string Login { get; set; }

        public string Browser { get; set; }
    }
}