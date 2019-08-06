using Microsoft.Extensions.Options;
using Promotion.Library;

namespace Promotion.Proxy
{
    public class ManagementEndpointFactory : EndpointFactory, IManagementEndpointFactory
    {
        public ManagementEndpointFactory(IOptions<ManagementConfiguration> configuration) : base(configuration) { }
    }
}
