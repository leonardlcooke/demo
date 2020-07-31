using Demo.Api.MobileCoach;
using Demo.Helpers;
using Demo.PartnerIntegrations;
using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;
using System.Net.Http.Headers;
using System.Text;

namespace Demo.Api
{
    public class MobileCoachEndpoint : IApiEndpoint
    {
        private readonly IAssociateService _associateService;
        private readonly IRequestParsingService _requestParsing;
        private readonly IEncryptionService _encryptionService;


        public MobileCoachEndpoint(IAssociateService associateService, IRequestParsingService requestParsing, IEncryptionService encryptionService)
        {
            _associateService = associateService;
            _requestParsing = requestParsing;
            _encryptionService = encryptionService;
        }

        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "demo/GetMobileCoachChatBotData",
                RequireAuthentication = false
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            var rObject = _requestParsing.ParseBody<MobileCoachRequest>(request);

            // Validate the request just a little
            if (rObject == null || rObject.AssociateId == 0)
            {
                return new ApiResponse { Content = Encoding.Unicode.GetBytes("Nothing"), MediaType = "JSON", StatusCode = System.Net.HttpStatusCode.NotFound };
            }
            var mobileCoachService = new MobileCoachService(_associateService, _encryptionService);

            return new Ok(mobileCoachService.GetMobileCoachChecksum(rObject.AssociateId));
        }
    }
}