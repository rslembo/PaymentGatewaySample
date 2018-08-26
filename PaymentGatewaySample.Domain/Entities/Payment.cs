using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public byte? Installments { get; set; }
        public string SoftDescriptor { get; set; }
        public PaymentType Type { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}