using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Merchant
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string BillingName { get; set; }
        public IEnumerable<MerchantPaymentConfiguration> PaymentConfigurations { get; set; }
        public MerchantAntifraudConfiguration AntifraudConfiguration { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}