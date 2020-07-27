using System;
using System.Collections.Generic;
using Config.Net;

namespace Basin.Config.Interfaces
{
    public interface IBrowserConfig
    {
        string Id { get; set; }

        string Kind { get; set; }

        [Option(DefaultValue = 10)]
        int Timeout { get; set; }

        [Option(DefaultValue = 2)]
        int ElementTimeout { get; set; }

        string PlatformName { get; set; }

        string Version { get; set; }

        IEnumerable<string> Arguments { get; }

        [Option(DefaultValue = false)]
        bool Headless { get; set; }

        [Option(DefaultValue = false)]
        bool AcceptsInsecureCerts { get; set; }

        string PathToDriverBinary { get; set; }

        string PathToBrowserExecutable { get; set; }

        Uri Host { get; set; }

        Dictionary<string, object> Capabilities { get; }
    }

    public class BrowserConfig : IBrowserConfig
    {
        public string Id { get; set; }

        public string Kind { get; set; }

        public int Timeout { get; set; }

        public int ElementTimeout { get; set; }

        public string PlatformName { get; set; }

        public string Version { get; set; }

        public IEnumerable<string> Arguments { get; set; }

        public bool Headless { get; set; }

        public string PathToDriverBinary { get; set; }

        public string PathToBrowserExecutable { get; set; }

        public Uri Host { get; set; }

        public bool AcceptsInsecureCerts { get; set; }

        public Dictionary<string, object> Capabilities { get; }
    }
}