using PaymentGatewaySample.Domain.Enums;
using System;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class CreditCard
    {
        public string Number { get; set; }
        public string Holder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public CardBrand Brand { get; set; }
    }
}