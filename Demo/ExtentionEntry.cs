﻿using Microsoft.Extensions.DependencyInjection;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Api;
using Demo.Views;
using Demo.Api;
using Demo.Merchants;
using System.Data;
using System.Data.SqlClient;
using DirectScale.Disco.Extension.Services;

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

            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(sp.GetService<IDataService>().ConnectionString.ConnectionString));
        }
    }
}
