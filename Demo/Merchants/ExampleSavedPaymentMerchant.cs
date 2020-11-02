using System;
using DirectScale.Disco.Extension;

namespace Demo.Merchants
{
    public class ExampleSavedPaymentMerchant : SavedPaymentMoneyInMerchant
    {
        public ExampleSavedPaymentMerchant() : base(
            new MerchantInfo
            {
                Currency = "USD",
                DisplayName = "ExampleDemo",
                Id = 9944,
                MerchantName = "Example Saved Payment Merchant"
            }, 500, 500
        ){}

        public override PaymentResponse ChargePayment(string payerId, NewPayment payment, int orderNumber)
        {
            throw new Exception("Unable to Charge Payment");

        }

        public override SavePaymentForm GetSavePaymentForm(string payerId, int associateId, string languageCode, string countryCode)
        {
            throw new Exception("Unable to Get Payment Form");
        }

        public override PaymentResponse RefundPayment(string payerId, int orderNumber, string currencyCode, double paymentAmount, double refundAmount, string referenceNumber, string transactionNumber, string authorizationCode)
        {
            throw new Exception("Unable to Refund Payment");
        }
    }
}
