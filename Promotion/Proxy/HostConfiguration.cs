using Promotion.Models;

namespace Promotion.Proxy
{
    public class HostConfiguration
    {
        public HostConfiguration() { }

        public HostConfiguration(string host, string path)
        {
            Host = host;
            Path = path;
        }

        public string Host { get; set; }

        public Credntial Credential { get; set; }

        public string Path { get; set; } = "/";
    }
}
