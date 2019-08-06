using Promotion.Proxy;

namespace Promotion.Library
{
    public interface IEndpointFactory
    {
        IEndpoint Create(string path);
    }
}
