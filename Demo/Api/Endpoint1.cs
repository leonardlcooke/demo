using Dapper;
using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;
using System.Data;
using System.Linq;

namespace Demo.Api
{
    public class Endpoint1 : IApiEndpoint
    {
        private readonly IAssociateService _associateService;
        private readonly IRequestParsingService _requestParsing;
        private readonly ILoggingService _logger;
        private readonly ITreeService _treeService;

        public Endpoint1(IAssociateService associateService, IRequestParsingService requestParsing, ILoggingService logger, ITreeService treeService)
        {
            _associateService = associateService;
            _requestParsing = requestParsing;
            _logger = logger;
            _treeService = treeService;
        }

        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "demo/end1",
                RequireAuthentication = false
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            //using (var dbConnection = new System.Data.SqlClient.SqlConnection(_dataService.ConnectionString.ConnectionString))
            {
                var rObject = _requestParsing.ParseBody<E1Request>(request);
                //var treeResult = _treeService.GetDownlineIds(new DirectScale.Disco.Extension.NodeId(2), DirectScale.Disco.Extension.TreeType.Unilevel, 100);

                var info = _associateService.GetAssociate(rObject.BackOfficeId);
                var associates = _associateService.GetAssociates(new[] { 1, 2 });

                return new Ok(new { Status = 1, RequestMessage = $"Updated {rObject.Message}.", AssociateName = info.Name });
            }
        }
    }

    public class QryResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BackOfficeId { get; set; }
    }

    public class E1Request
    {
        public string Message { get; set; }
        public string BackOfficeId { get; set; }
    }
}