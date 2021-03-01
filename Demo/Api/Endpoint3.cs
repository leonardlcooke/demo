using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;

namespace Demo.Api
{
    public class Endpoint3 : ApiEndpoint<Endpoint3Request>
    {
        private readonly IStatsService _statsService;

        public Endpoint3(IRequestParsingService parsingService, IStatsService statsService) : base("demo/end3", parsingService)
        {
            _statsService = statsService;
        }

        public override IApiResponse Post(Endpoint3Request request)
        {
            return new Ok(_statsService.GetStats(new[] { 2 }, System.DateTime.Now));
        }
    }
}
