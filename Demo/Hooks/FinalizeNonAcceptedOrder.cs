using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Orders;
using DirectScale.Disco.Extension.Services;
using FlexPay;

namespace Demo.Hooks
{
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
}
