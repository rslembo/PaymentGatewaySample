using PaymentGatewaySample.Domain.Contracts.Models;
using PaymentGatewaySample.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Domain.Contracts
{
    public class SaleResponse
    {
        public Guid TransactionId { get; set; }
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        public TransactionStatus Status { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public FraudAnalysis FraudAnalysis { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}