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

                using (_logger.BeginScope("Test order {OrderId} for customer {CustomerId}", 54, 12345))
                {
                    var eventId = new EventId(2, "Test Event");
                    _logger.Log(request.LogLevel, eventId, request.Message, new object[] { "Obj1", DateTime.Now });

                    _logger.LogInformation("In scope");
                }

                using (_logger.BeginScope(new System.Collections.Generic.Dictionary<string, object>
                {
                    ["CustomerId"] = 12345,
                    ["OrderId"] = 54
                }))
                {
                    _logger.LogInformation("Processing credit card payment");
                }

                using (_logger.BeginScope(42))
                {
                    using (_logger.BeginScope("Example"))
                    {
                        using (_logger.BeginScope("https://example.com"))
                        {
                            _logger.LogInformation("Hello, world!");
                        }
                    }
                }

                _logger.LogInformation("After scope");
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
