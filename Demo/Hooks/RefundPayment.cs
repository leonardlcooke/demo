using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Orders;
//using FlexPay;

namespace Demo.Hooks
{
    public class RefundPayment : IHook<RefundPaymentHookRequest, RefundPaymentHookResponse>
    {
        //private readonly IFlexPayService _flexPayService;

        public RefundPayment()
        {
            //_flexPayService = flexPayService;
        }

        public RefundPaymentHookResponse Invoke(RefundPaymentHookRequest request, Func<RefundPaymentHookRequest, RefundPaymentHookResponse> func)
        {
            var result = func.Invoke(request);

            //_flexPayService.NotifyOfRefund(request.OrderNumber);

            return result;
        }
    }
}
