using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Orders;
using FlexPay;

namespace Demo.Hooks
{
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
}