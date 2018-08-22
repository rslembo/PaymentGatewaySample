using PaymentGatewaySample.Domain.Enums;
using System;

namespace PaymentGatewaySample.Domain.Entities
{
    public class MerchantPaymentConfiguration
    {
        public Guid Id { get; set; }
        public Guid MerchantId { get; set; }
        public CardBrand Brand { get; set; }
        public Acquirer Acquirer { get; set; }
    }
}