using System;

namespace Basin.Config.Interfaces
{
    public interface IDriverConfig
    {
        int Timeout { get; set; }

        string Browser { get; set; }

        string PathToDrivers { get; set; }

        Uri Host { get; set; }
    }
}