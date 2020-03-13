using System;
using DirectScale.Disco.Extension;
using DirectScale.Disco.Extension.Hooks.Merchants.ExtendedMerchants;
using DirectScale.Disco.Extension.Hooks;

namespace Demo
{
    public class GetMerchantHook : IHook<GetExtendedMerchantsHookRequest, GetExtendedMerchantsHookResponse>
    {
        public GetExtendedMerchantsHookResponse Invoke(GetExtendedMerchantsHookRequest request, Func<GetExtendedMerchantsHookRequest, GetExtendedMerchantsHookResponse> func)
        {
            var res = func(request);

            return new GetExtendedMerchantsHookResponse
            {
                MerchantInfos = new ExtendedMerchant[]
                {
                    new ExtendedMerchant
                    {
                        Autoship = false,
                        Id = 322,
                        CanCharge = true,
                        Currency = "UsD",
                        DisplayText = "Demo Merchant",
                        Name = "DemoMerchant",
                        CanSavePayments = false
                    }
                }
            };
        }
    }
}
