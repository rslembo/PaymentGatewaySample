using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Merchant
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string BillingName { get; set; }
        public virtual IEnumerable<MerchantPaymentConfiguration> PaymentConfigurations { get; set; }
        public virtual MerchantAntifraudConfiguration AntifraudConfiguration { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}