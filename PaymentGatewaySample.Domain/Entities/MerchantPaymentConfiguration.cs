using PaymentGatewaySample.Domain.Enums;
using System;

namespace PaymentGatewaySample.Domain.Entities
{
    public class MerchantPaymentConfiguration
    {
        public Guid Id { get; set; }
        public virtual Merchant Merchant { get; set; }
        public CardBrand Brand { get; set; }
        public Acquirer Acquirer { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid AcquirerMerchantId { get; set; }
        public string AcquirerMerchantKey { get; set; }
    }
}