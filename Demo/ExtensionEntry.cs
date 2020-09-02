﻿using Microsoft.Extensions.DependencyInjection;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Api;
using Demo.Api;
using Demo.Merchants;
using MobileCoach;
using DirectScale.Disco.Extension.Hooks.Associates.Enrollment;
using Demo.Hooks;
using Demo.Logging;

namespace Demo
{
    public class ExtensionEntry : IExtension
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDemoService, DemoService>();

            services.AddSingleton<IApiEndpoint, Endpoint1>();
            services.AddSingleton<IApiEndpoint, Endpoint2>();
            services.AddSingleton<IApiEndpoint, Endpoint3>();
            
            services.AddScoped<IMoneyInMerchant, ExampleRedirectMerchant>();

            // Partner implementations here:
            services.UseMobileCoach(new MobileCoachDirectScale.Config
            {
                Token = "8Nzegi_iIgVgwHRiOOZD9_oGp13LkXueLxiS",
                SecretKey = "mWloZHnf6SOXot1rbPcTrAlGJXAdHTupV7LI",
                UrlKey = "134a9bac6f4532fe75399b2371377313e780698797b2dc4ba72fbe425da27db4",
                BaseUrl = "https://qa.mobilecoach.com/widgets/" //"https://admin.mobilecoach.com/widgets/"
            });

            // Simple hook example:
            services.AddTransient<IHook<IsEmailAvailableHookRequest, IsEmailAvailableHookResponse>, IsEmailAvailableHook>();

            // Logging
            services.AddSingleton<IDiscoExtensionLogger, DiscoExtensionLogger>();

            // Transient: Create a new one every time.
            // Singleton: Once in life of service. Cleared when IIS restarts.
            // Scoped: Once per HTTPContext request
        }
    }
}
