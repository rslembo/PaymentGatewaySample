using System;

namespace PaymentGatewaySample.Integrations.Cielo.Contracts.Models
{
    public class CieloMerchantCredential
    {
        public Guid MerchantId { get; set; }
        public string MerchantKey { get; set; }

        public CieloMerchantCredential(Guid merchantId, string merchantKey)
        {
            MerchantId = merchantId;
            MerchantKey = merchantKey;
        }
    }
}