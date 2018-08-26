using PaymentGatewaySample.Integrations.Stone.Enums;
using System;

namespace PaymentGatewaySample.Integrations.Stone.Contracts.Models
{
    public class CreditCard
    {
        public CreditCardBrand CreditCardBrand { get; set; }
        public Guid InstantBuyKey { get; set; }
        public bool IsExpiredCreditCard { get; set; }
        public string MaskedCreditCardNumber { get; set; }
    }
}