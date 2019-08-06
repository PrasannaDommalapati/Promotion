using Microsoft.Extensions.Options;
using Promotion.Proxy;
using System.Net.Http;

namespace Promotion.Library
{
    public class EndpointFactory : IEndpointFactory
    {
        public EndpointFactory(IOptions<HostConfiguration> uriConfiguration) : this(uriConfiguration.Value) { }

        public EndpointFactory(HostConfiguration uriConfiguration)
        {
            Configuration = uriConfiguration;
        }

        public EndpointFactory(HttpClient client, HostConfiguration uriConfiguration)
        {
            HttpClient = client;
            Configuration = uriConfiguration;
        }

        public HostConfiguration Configuration { get;}

        public HttpClient HttpClient { get; set; }

        public IEndpoint Create(string path)
        {
            var uriConfiguration = new HostConfiguration
            {
                Credential = Configuration.Credential,
                Host = Configuration.Host,
                Path = path
            };

            var endpoint = new Endpoint(uriConfiguration);
            endpoint.AddHeader(
                uriConfiguration.Credential.Id,
                uriConfiguration.Credential.Key);

            return endpoint;
        }
    }
}
