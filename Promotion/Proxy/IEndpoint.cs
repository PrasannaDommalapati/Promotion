using System.Net.Http;
using System.Threading.Tasks;

namespace Promotion.Proxy
{
    public interface IEndpoint
    {
        HttpClient Client { get; }

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest data) where TRequest : class where TResponse : class;

        Task<TResponse> GetAsync<TResponse>(params string[] parameters) where TResponse : class;

        void AddHeader(string name, string value);
    }
}
