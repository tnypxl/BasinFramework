using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IEnvironmentConfig
    {
        string Site { get; set; }

        string Login { get; set; }

        string Browser { get; set; }
    }
}