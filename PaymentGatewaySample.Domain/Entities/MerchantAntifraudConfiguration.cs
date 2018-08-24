using PaymentGatewaySample.Domain.Enums;
using System;

namespace PaymentGatewaySample.Domain.Entities
{
    public class MerchantAntifraudConfiguration
    {
        public Guid Id { get; set; }
        public virtual Merchant Merchant { get; set; }
        public AntifraudProvider Provider { get; set; }
        public bool IsEnabled { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}