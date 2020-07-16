using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class MobileCoach : IApiEndpoint
    {
        public MobileCoach()
        {
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
            return new Ok(new { name = "Hello World!", requestBody = request.Body });
        }
    }
}