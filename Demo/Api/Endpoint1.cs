using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;

namespace Demo.Api
{
    public class Endpoint1 : IApiEndpoint
    {
        private readonly IAssociateService _associateService;

        public Endpoint1(IAssociateService associateService)
        {
            _associateService = associateService;
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
            var rObject = RequestParser.ParseBody<E1Request>(request);

            var aName = _associateService.GetAssociate(rObject.BackOfficeId).Name;

            return new Ok(new { Status = 1, RequestMessage = rObject.Message, AssociateName = aName });
        }
    }

    public class E1Request
    {
        public string Message { get; set; }
        public string BackOfficeId { get; set; }
    }
}