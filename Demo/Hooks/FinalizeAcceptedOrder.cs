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
        private readonly ILoggingService _logService;
        //private readonly IFlexPayService _flexPayService;

        public FinalizeAcceptedOrder(IEventService eventService, ILoggingService logService)
        {
          //  _flexPayService = flexPayService;
            _eventService = eventService;
            _logService = logService;
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
            try
            {
                _eventService.PostEvent("DemoOrderCreated", new
                {
                    OrderID = request.Order.OrderNumber,
                    NameOnOrder = request.Order.Name,
                    OrderCreatedDate = request.Order.OrderDate
                });
            } catch (Exception e)
            {
                _logService.LogError(e, "Could not send order event to Event Engine.");
            }
        }
    }
}