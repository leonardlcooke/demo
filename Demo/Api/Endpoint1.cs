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

        public string Post(ApiRequest request)
        {
            return "Success";
        }
    }
}