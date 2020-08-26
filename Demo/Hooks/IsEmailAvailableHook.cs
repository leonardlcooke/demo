using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Associates.Enrollment;

namespace Demo.Hooks
{
    public class IsEmailAvailableHook : IHook<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse>
    {
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
            
            // ... and return the response.
            return response;
        }
    }
}
