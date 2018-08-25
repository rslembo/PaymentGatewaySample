using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Holder { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string SecurityCode { get; set; }
        public CardBrand Brand { get; set; }
        public virtual Payment Payment { get; set; }
    }
}