using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class Payment
    {
        public PaymentType Type { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public byte Installments { get; set; }
        public bool? Capture { get; set; }
        public string SoftDescriptor { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}