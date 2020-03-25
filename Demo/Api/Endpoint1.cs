using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint1 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "v2/custom/end1",
                RequireAuthentication = true
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            return new Ok(new { Status = 1, Message = "Success" });
        }
    }
}