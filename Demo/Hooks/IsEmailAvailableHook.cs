using System;
using Demo.Logging;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Associates.Enrollment;

namespace Demo.Hooks
{
    public class IsEmailAvailableHook : IHook<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse>
    {
        private readonly IDiscoExtensionLogger _logger;
        
        public IsEmailAvailableHook(IDiscoExtensionLogger logger)
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

            _logger.LogInfo($"This is a log message! Email Available? {response.IsAvailable}");

            // ... and return the response.
            return response;
        }
    }
}
