using PaymentGatewaySample.Domain.Enums;
using System;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        public TransactionStatus Status { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual FraudAnalysis FraudAnalysis { get; set; }

        public virtual Merchant Merchant { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ProofOfSale { get; set; }
        public string AcquirerTransactionKey { get; set; }
        public string AuthorizationCode { get; set; }
        public Guid? AcquirerTransactionId { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }
}