using Microsoft.Extensions.DependencyInjection;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Api;
using Demo.Api;
using Demo.Merchants;
using MobileCoach;
using DirectScale.Disco.Extension.Hooks.Associates.Enrollment;
using Demo.Hooks;
using Demo.Logging;
using FlexPay;
using DirectScale.Disco.Extension.Hooks.Orders;
using DirectScale.Disco.Extension.Hooks.Associates;

namespace Demo
{
    public class ExtensionEntry : IExtension
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Logging
            services.AddSingleton<IDiscoExtensionLogger, DiscoExtensionLogger>();

            services.AddSingleton<IDemoService, DemoService>();

            services.AddSingleton<IApiEndpoint, Endpoint1>();
            services.AddSingleton<IApiEndpoint, Endpoint2>();
            services.AddSingleton<IApiEndpoint, Endpoint3>();
            services.AddSingleton<IApiEndpoint, LoggerTests>();
            services.AddSingleton<IApiEndpoint, GetExtensionContext>();

            services.AddScoped<IMoneyInMerchant, ExampleRedirectMerchant>();

            // Partner implementations here:
            services.UseMobileCoach(new MobileCoachDirectScale.Config
            {
                Token = "jFFLVWmeIvmyxBD3zCUnubO0DYNoluRplWqS",
                SecretKey = "NDPWvj1Tm1doSfKgNJ2v3Z0yxJotG3iaenbZ",
                UrlKey = "6273b89386aa97020d7590e3a36dc888eae0096d474bab915b0aa89b82138dac",
                BaseUrl = "https://admin.mobilecoach.com/widgets/" // "https://qa.mobilecoach.com/widgets/"
            });

            // Simple hook example:
            services.AddTransient<IHook<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse>, IsEmailAvailable>();
            services.AddTransient<IHook<UpdateAssociateHookRequest, UpdateAssociateHookResponse>, UpdateAssociate>();

            //
            // FlexPay Additions
            //
            services.AddTransient<IHook<RefundPaymentHookRequest, RefundPaymentHookResponse>, RefundPayment>();
            services.AddTransient<IHook<FinalizeNonAcceptedOrderHookRequest, FinalizeNonAcceptedOrderHookResponse>, FinalizeNonAcceptedOrder>();
            services.AddTransient<IHook<FinalizeAcceptedOrderHookRequest, FinalizeAcceptedOrderHookResponse>, FinalizeAcceptedOrder>();
            services.UseFlexPay();

            // Transient: Create a new one every time.
            // Singleton: Once in life of service. Cleared when IIS restarts.
            // Scoped: Once per HTTPContext request
        }
    }
}
