using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Associates.Enrollment;
using DirectScale.Disco.Extension.Services;

namespace Demo.Hooks
{
    public class IsEmailAvailable : IHook<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse>
    {
        private readonly ILoggingService _logger;
        
        public IsEmailAvailable(ILoggingService logger)
        {
            _logger = logger;
        }

        public IsEmailAvailableHookResponse Invoke(IsEmailAvailableHookRequest request, Func<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse> func)
        {
        
            // Call the original, unhooked function 
            var response = func(request);

            // Adjust the response of the original function as necessary.
            if (response.IsAvailable)
            {
                if (request.EmailAddress == "testemail@directscale.com")
                {
                    response.IsAvailable = false;
                }
            }

            _logger.LogInformation($"This is a log message! Email Available? {response.IsAvailable}");

            // ... and return the response.
            return response;
        }
    }
}
