using System.Web;
using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint1 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Endpoint = "v2/custom/end1",
                RequireAuthentication = true
            };
        }

        public object Post(HttpRequest request)
        {
            return new { Status = 1, Message = "Success" };
        }
    }
}