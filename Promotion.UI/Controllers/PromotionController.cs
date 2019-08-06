using Microsoft.AspNetCore.Mvc;
using Promotion.Models;
using Promotion.Proxy;
using System.Threading.Tasks;

namespace Promotion.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : Controller
    {
        public IPromotionsEndpointFactory EndpointFactory { get; set; }

        public PromotionController(IPromotionsEndpointFactory promotionsEndpointFactory) => EndpointFactory = promotionsEndpointFactory;

        [HttpGet("users/{id}")]
        public async Task<PostData> GetUser(string id)
        {
            return await EndpointFactory
                .Create(UriPaths.GetUserEndpoint)
                .GetAsync<PostData>(id)
                .ConfigureAwait(false);
        }

        [HttpPost("request")]
        public async Task<ResponseData> UploadSigmaReq([FromBody]
            [Bind(nameof(RequestData.RequesterId),
            nameof(RequestData.Data),
            nameof(RequestData.BusinessApplication),
            nameof(RequestData.BusinessUnit),
            nameof(RequestData.Metadata))] RequestData request)
        {
            return await EndpointFactory
                .Create(UriPaths.RequestsEndpoint)
                .PostAsync<RequestData, ResponseData>(request)
                .ConfigureAwait(false);
        }
    }
}
