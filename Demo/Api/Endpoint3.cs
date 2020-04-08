using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint3 : ApiEndpoint<Endpoint3Request>
    {
        public Endpoint3(IRequestParsingService parsingService) : base("demo/end3", parsingService)
        {

        }

        public override IApiResponse Post(Endpoint3Request request)
        {
            throw new System.NotImplementedException();
        }
    }
}
