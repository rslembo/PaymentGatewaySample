using PaymentGatewaySample.Integrations.Cielo.Contracts.Models;
using System;

namespace PaymentGatewaySample.Integrations.Cielo.Contracts
{
    public class CieloRequest
    {
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        public Payment Payment { get; set; }
    }
}