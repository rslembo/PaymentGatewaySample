using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class PaymentDto
    {
        public long? Amount { get; set; }
        public string Currency { get; set; }
        public byte Installments { get; set; }
        public string SoftDescriptor { get; set; }
        public PaymentType Type { get; set; }
        public CreditCardDto CreditCard { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}