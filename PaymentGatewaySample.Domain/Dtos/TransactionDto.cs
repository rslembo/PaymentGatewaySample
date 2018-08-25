using PaymentGatewaySample.Domain.Enums;
using System;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        public TransactionStatus Status { get; set; }
        public CustomerDto Customer { get; set; }
        public PaymentDto Payment { get; set; }
        public FraudAnalysisDto FraudAnalysis { get; set; }

        public Guid MerchantId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}