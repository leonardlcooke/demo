using Microsoft.Extensions.DependencyInjection;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Api;
using Demo.Api;
using Demo.Merchants;
using DirectScale.Disco.Extension.Hooks.Orders;
using System;
using FlexPay;
using DirectScale.Disco.Extension.Services;

namespace Demo
{
    public class ExtensionEntry : IExtension
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDemoService, DemoService>();

            services.AddSingleton<IApiEndpoint, Endpoint1>();
            //services.AddSingleton<IApiEndpoint, Endpoint2>();
            //services.AddSingleton<IApiEndpoint, Endpoint3>();
                
            services.AddScoped<IMoneyInMerchant, ExampleRedirectMerchant>();

            services.AddTransient<IHook<RefundPaymentHookRequest, RefundPaymentHookResponse>, RefundPayment>();
            services.AddTransient<IHook<FinalizeNonAcceptedOrderHookRequest, FinalizeNonAcceptedOrderHookResponse>, FinalizeNonAcceptedOrder>();
            services.AddTransient<IHook<FinalizeAcceptedOrderHookRequest, FinalizeAcceptedOrderHookResponse>, FinalizeAcceptedOrder>();
            services.UseFlexPay();

            // Transient: Create a new one every time.
            // Singleton: Once in life of service. Cleared when IIS restarts.
            // Scoped: Once per HTTPContext request
        }

        public class FinalizeNonAcceptedOrder : IHook<FinalizeNonAcceptedOrderHookRequest, FinalizeNonAcceptedOrderHookResponse>
        {
            private readonly IFlexPayService _flexPayService;
            private readonly IOrderService _orderService;

            public FinalizeNonAcceptedOrder(IFlexPayService flexPayService, IOrderService orderService)
            {
                _flexPayService = flexPayService;
                _orderService = orderService;
            }

            public FinalizeNonAcceptedOrderHookResponse Invoke(FinalizeNonAcceptedOrderHookRequest request, Func<FinalizeNonAcceptedOrderHookRequest, FinalizeNonAcceptedOrderHookResponse> func)
            {
                try
                {
                    _flexPayService.GetRecommendation(request.Order, new FlexPay.Models.BillingInfo
                        {
                            BillingAddress = new FlexPay.Models.Address
                            {
                                Address1 = "123 Test St",
                                City = "Orem",
                                State = "UT",
                                Country = "US",
                                PostalCode = "84058"
                            },
                            FirstSixDigits = "123456",
                            LastFourDigits = "1111",
                            GatewayType = FlexPay.Models.GatewayType.nmi,
                            GatewayCode = "TG",
                            GatewayMessage = "This is a test"
                        }
                    );
                }
                catch (Exception e)
                {
                    _orderService.Log(request.Order.OrderNumber, $"Demo - {e.Message}");
                }

                return func.Invoke(request);
            }
        }

        public class FinalizeAcceptedOrder : IHook<FinalizeAcceptedOrderHookRequest, FinalizeAcceptedOrderHookResponse>
        {
            private readonly IFlexPayService _flexPayService;

            public FinalizeAcceptedOrder(IFlexPayService flexPayService)
            {
                _flexPayService = flexPayService;
            }

            public FinalizeAcceptedOrderHookResponse Invoke(FinalizeAcceptedOrderHookRequest request, Func<FinalizeAcceptedOrderHookRequest, FinalizeAcceptedOrderHookResponse> func)
            {
                _flexPayService.NotifyOfOrderSuccess(request.Order);

                return func.Invoke(request);
            }
        }

        public class RefundPayment : IHook<RefundPaymentHookRequest, RefundPaymentHookResponse>
        {
            private readonly IFlexPayService _flexPayService;

            public RefundPayment(IFlexPayService flexPayService)
            {
                _flexPayService = flexPayService;
            }

            public RefundPaymentHookResponse Invoke(RefundPaymentHookRequest request, Func<RefundPaymentHookRequest, RefundPaymentHookResponse> func)
            {
                var result = func.Invoke(request);

                _flexPayService.NotifyOfRefund(request.OrderNumber);

                return result;
            }
        }
    }
}
