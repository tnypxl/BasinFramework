using System;
using System.Collections.Generic;

namespace Basin.Config.Interfaces
{
    public interface IBrowserConfig
    {
        string Id { get; set; }

        string Kind { get; set; }

        int Timeout { get; set; }

        string PlatformName { get; set; }

        string Version { get; set; }

        IEnumerable<string> Arguments { get; }

        bool Headless { get; set; }

        string PathToDriverBinary { get; set; }

        string PathToBrowserExecutable { get; set; }

        Uri Host { get; set; }
    }

    public class BrowserConfig : IBrowserConfig
    {
        public string Id { get; set; }

        public string Kind { get; set; }

        public int Timeout { get; set; }

        public string PlatformName { get; set; }

        public string Version { get; set; }

        public IEnumerable<string> Arguments { get; set; }

        public bool Headless { get; set; }

        public string PathToDriverBinary { get; set; }

        public string PathToBrowserExecutable { get; set; }

        public Uri Host { get; set; }
    }
}