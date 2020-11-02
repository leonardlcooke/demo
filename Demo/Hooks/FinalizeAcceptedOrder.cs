using System;
using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Orders;
using DirectScale.Disco.Extension.Services;
//using FlexPay;

namespace Demo.Hooks
{
    public class FinalizeAcceptedOrder : IHook<FinalizeAcceptedOrderHookRequest, FinalizeAcceptedOrderHookResponse> 
    {
        private readonly IEventService _eventService;
        //private readonly IFlexPayService _flexPayService;

        public FinalizeAcceptedOrder(IEventService eventService)
        {
          //  _flexPayService = flexPayService;
            _eventService = eventService;
        }

        public FinalizeAcceptedOrderHookResponse Invoke(FinalizeAcceptedOrderHookRequest request, Func<FinalizeAcceptedOrderHookRequest, FinalizeAcceptedOrderHookResponse> func)
        {
            SendOrderCreateEvent(request);
            
            //_flexPayService.NotifyOfOrderSuccess(request.Order);

            return func.Invoke(request);
        }
        
        /// <summary>
        /// Example of sending an event using the DS event bus.
        /// </summary>
        /// <param name="request"></param>
        private void SendOrderCreateEvent(FinalizeAcceptedOrderHookRequest request)
        {
            _eventService.PostEvent("DemoOrderCreated", new
            {
                OrderID = request.Order.OrderNumber,
                NameOnOrder = request.Order.Name,
                OrderCreatedDate = request.Order.OrderDate
            });
        }
    }
}