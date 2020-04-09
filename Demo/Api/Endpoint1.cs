using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;

namespace Demo.Api
{
    public class Endpoint1 : IApiEndpoint
    {
        private readonly IAssociateService _associateService;
        private readonly IRequestParsingService _requestParsing;

        public Endpoint1(IAssociateService associateService, IRequestParsingService requestParsing)
        {
            _associateService = associateService;
            _requestParsing = requestParsing;
        }

        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "demo/end1",
                RequireAuthentication = false
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            var clientId = System.Environment.GetEnvironmentVariable("client");
            var rObject = _requestParsing.ParseBody<E1Request>(request);
            var aName = _associateService.GetAssociate(rObject.BackOfficeId).Name;

            return new Ok(new { Status = 1, RequestMessage = rObject.Message, AssociateName = aName, client = clientId });
        }
    }

    public class E1Request
    {
        public string Message { get; set; }
        public string BackOfficeId { get; set; }
    }
}