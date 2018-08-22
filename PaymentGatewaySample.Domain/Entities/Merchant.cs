using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Merchant
    {
        public Guid Id { get; set; }
        public string BillingName { get; set; }
        public bool AntifraudEnabled { get; set; }
        public IEnumerable<MerchantPaymentConfiguration> PaymentConfiguration { get; set; }
    }
}