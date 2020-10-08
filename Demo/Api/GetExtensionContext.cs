using DirectScale.Disco.Extension.Api;
using DirectScale.Disco.Extension.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Api
{
    public class GetExtensionContext : IApiEndpoint
    {
        ISettingsService _settingsService;

        public GetExtensionContext(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Route = "GetContext",
                RequireAuthentication = false
            };
        }

        public IApiResponse Post(ApiRequest request)
        {
            return new Ok(_settingsService.ExtensionContext());
        }
    }
}
