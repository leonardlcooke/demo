using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;

namespace Demo.Api
{
    public class Endpoint3 : IApiEndpoint
    {
        private readonly IStatsService _statsService;

        public Endpoint3(IRequestParsingService parsingService, IStatsService statsService)
        {
            _statsService = statsService;
        }

        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "demo/end3",
                RequireAuthentication = false
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            var stats = _statsService.GetStats(new[] { 2 }, System.DateTime.Now);
            return new Ok(stats);
        }
    }
}
