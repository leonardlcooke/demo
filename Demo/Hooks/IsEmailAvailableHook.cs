using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Associates.Enrollment;

namespace Demo.Hooks
{
    public class IsEmailAvailableHook : IHook<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse>
    {
        public IsEmailAvailableHookResponse Invoke(IsEmailAvailableHookRequest request, Func<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse> func)
        {
            if (request.EmailAddress == "testemail@directscale.com")
            {
                return new IsEmailAvailableHookResponse
                {
                    IsAvailable = false
                };
            } else
            {
                return new IsEmailAvailableHookResponse
                {
                    IsAvailable = true
                };
            } 
        }
    }
}
