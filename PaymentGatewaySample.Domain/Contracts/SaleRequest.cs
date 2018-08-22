using PaymentGatewaySample.Domain.Contracts.Models;
using System;

namespace PaymentGatewaySample.Domain.Contracts
{
    public class SaleRequest
    {
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}