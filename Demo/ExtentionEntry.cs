using Microsoft.Extensions.DependencyInjection;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks.Merchants.ExtendedMerchants;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Api;
using System.Web;

namespace Demo
{
    public class ExtensionEntry : IExtension
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHook<GetExtendedMerchantsHookRequest, GetExtendedMerchantsHookResponse>, GetMerchantHook>();

            services.AddSingleton<IApiEndpoint, Endpoint1>();
            services.AddSingleton<IApiEndpoint, Endpoint2>();

            services.AddSingleton<IViewEndpoint, View1>();
        }
    }

    public class View1 : IViewEndpoint
    {
        public ViewDefinition GetDefinition()
        {
            return new ViewDefinition
            {
                Menu = Menu.Associates,
                SecurityRight = "",
                Title = "Custom V1"
            };
        }

        public View GetView(HttpRequest request)
        {
            return new View
            {
                Html = "<head></head><body><h1>View1 Page Title</h1></body>"
            };
        }
    }

    public class Endpoint1 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Endpoint = "v2/custom/end1",
                RequireAuthentication = true
            };
        }

        public object Post(HttpRequest request)
        {
            return new { Status = 1, Message = "Success" };
        }
    }

    public class Endpoint2 : IApiEndpoint
    {
        public ApiDefinition GetDefinition()
        {
            return new ApiDefinition
            {
                Endpoint = "v2/custom/end2",
                RequireAuthentication = false
            };
        }

        public object Post(HttpRequest request)
        {
            return new { Status = 2, Message = "Success" };
        }
    }
}
