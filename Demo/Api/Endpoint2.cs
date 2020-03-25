using System.Web;
using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint2 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Endpoint = "v2/custom/end2",
                RequireAuthentication = false
            };
        }

        public object Post(HttpRequest request)
        {
            return new { Status = 2, Message = "Success" };
        }
    }
}
