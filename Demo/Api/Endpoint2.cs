using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint2 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "v2/custom/end2",
                RequireAuthentication = false
            };
        }

        public string Post(ApiRequest request)
        {
            return "Success";
        }
    }
}
