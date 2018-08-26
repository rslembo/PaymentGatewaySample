using PaymentGatewaySample.Integrations.Stone.Enums;
using System;

namespace PaymentGatewaySample.Integrations.Stone.Contracts.Models
{
    public class CreditCardTransactionResult
    {
        public string AcquirerMessage { get; set; }
        public string AcquirerName { get; set; }
        public string AcquirerReturnCode { get; set; }
        public string AffiliationCode { get; set; }
        public long AmountInCents { get; set; }
        public string AuthorizationCode { get; set; }
        public long AuthorizedAmountInCents { get; set; }
        public long CapturedAmountInCents { get; set; }
        public DateTime CaptureDate { get; set; }
        public CreditCard CreditCard { get; set; }
        public CreditCardOperation CreditCardOperation { get; set; }
        public CreditCardTransactionStatus CreditCardTransactionStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public int ExternalTime { get; set; }
        public string PaymentMethodName { get; set; }
        public long? RefundedAmountInCents { get; set; }
        public bool Success { get; set; }
        public string TransactionIdentifier { get; set; }
        public Guid TransactionKey { get; set; }
        public string TransactionKeyToAcquirer { get; set; }
        public Guid TransactionReference { get; set; }
        public string UniqueSequentialNumber { get; set; }
        public long? VoidedAmountInCents { get; set; }
    }
}