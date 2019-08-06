using Microsoft.Extensions.Options;
using Promotion.Library;

namespace Promotion.Proxy
{
    public class PromotionsEndpointFactory: EndpointFactory, IPromotionsEndpointFactory
    {
        public PromotionsEndpointFactory(IOptions<PromotionsConfiguration> configuration) : base(configuration) { }
    }
}
