using System;

namespace PaymentGatewaySample.Integrations.Stone.Contracts.Models
{
    public class OrderResult
    {
        public DateTime CreateDate { get; set; }
        public Guid OrderKey { get; set; }
        public string OrderReference { get; set; }
    }
}