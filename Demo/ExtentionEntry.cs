using Microsoft.Extensions.DependencyInjection;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks.Merchants.ExtendedMerchants;
using DirectScale.Disco.Extension.Hooks;

namespace Demo
{
    public class ExtensionEntry : IExtension
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHook<GetExtendedMerchantsHookRequest, GetExtendedMerchantsHookResponse>, GetMerchantHook>();
        }

        public void Initialize(IExtendor extendor)
        {
            //extendor.AddPage(Menu.Associates, "V2", "V2")
            extendor.Hooks.Associates.Enrollment.GetNewBackOfficeId.Override = (r, f) =>
            {
                var res = f(r);

                return new DirectScale.Disco.Extension.Hooks.Associates.Enrollment.SetBackOfficeIdHookResponse
                {
                    BackOfficeId = res.BackOfficeId
                };
            };

            System.Func<TestRequest, string> v1 = (r) =>
            {
                return $"true - {r.Value}";
            };

            //extendor.AddAPI<TestRequest>("test/v1", v1);
        }
    }

    public class TestRequest : RequestBase
    {
        public string Value { get; set; }
    }
}
