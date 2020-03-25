using System;

namespace Basin.Config.Interfaces
{
    public interface IDatabaseConfig
    {
        Uri Host { get; set; }
        string Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}