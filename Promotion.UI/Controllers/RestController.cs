using Microsoft.AspNetCore.Mvc;
using Promotion.Models;
using Promotion.Proxy;
using System.Threading.Tasks;

namespace Promotion.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : Controller
    {
        public IManagementEndpointFactory EndpointFactory { get; set; }

        public RestController(IManagementEndpointFactory endpointFactory) => EndpointFactory = endpointFactory;

        [HttpGet("users/{id}")]
        public async Task<PostData> GetUser(string id)
        {
            return await EndpointFactory
                .Create(UriPaths.GetUserEndpoint)
                .GetAsync<PostData>(id)
                .ConfigureAwait(false);
        }

        [HttpGet("unknown")]
        public async Task<PostData> GetList()
        {
            return await EndpointFactory
                .Create(UriPaths.GetUsersListEndpoint)
                .GetAsync<PostData>()
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
                .PostAsync<RequestData,ResponseData>(request)
                .ConfigureAwait(false);
        }
    }
}
