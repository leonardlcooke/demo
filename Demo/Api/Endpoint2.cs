using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint2 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "demo/end2",
                RequireAuthentication = false
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            return new Ok(new { Status = 2, Message = "This is working." });
        }
    }
}
