using System;
using DirectScale.Disco.Extension;

namespace Demo.Merchants
{
    public class ExampleRedirectMerchant : RedirectMoneyInMerchant
    {
        public ExampleRedirectMerchant() : base(
            new MerchantInfo
            {
                Currency = "USD",
                DisplayName = "ExampleDemo",
                Id = 9933,
                MerchantName = "Example"
            }
        ){}

        public override PaymentResponse ChargePayment(int associateId, int orderNumber, Address billingAddress, double amount, string currencyCode, string redirectUrl)
        {
            throw new Exception("Unable to Charge Payment");
        }

        public override PaymentResponse RefundPayment(string payerId, int orderNumber, string currencyCode, double paymentAmount, double refundAmount, string referenceNumber, string transactionNumber, string authorizationCode)
        {
            throw new Exception("Unable to Refund Payment");
        }
    }
}
