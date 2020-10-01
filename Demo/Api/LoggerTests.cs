using System;
using DirectScale.Disco.Extension.Api;
using Microsoft.Extensions.Logging;

namespace Demo.Api
{
    public class LoggerTests : ApiEndpoint<LoggerTestRequest>
    {
        private readonly ILogger _logger;

        public LoggerTests(ILogger logger, IRequestParsingService requestParsingService) : base("LogItem", false, requestParsingService)
        {
            _logger = logger;
        }

        public override IApiResponse Post(LoggerTestRequest request)
        {
            try
            {
                if (request.ThrowError)
                {
                    throw new Exception("Expected Exception");
                }

                var eventId = new EventId(2, "Test Event");
                _logger.Log(request.LogLevel, eventId, request.Message, new object[] { "Obj1", DateTime.Now });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return new Ok();
        }

    }

    public class LoggerTestRequest
    {
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public bool ThrowError { get; set; }
    }
}
