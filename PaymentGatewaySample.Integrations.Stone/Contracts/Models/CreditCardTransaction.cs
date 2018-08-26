using PaymentGatewaySample.Integrations.Stone.Enums;

namespace PaymentGatewaySample.Integrations.Stone.Contracts.Models
{
    public class CreditCardTransaction
    {
        public long AmountInCents { get; set; }
        public CreditCardBrand CreditCardBrand { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int? SecurityCode { get; set; }
        public string HolderName { get; set; }
        public byte? InstallmentCount { get; set; }
    }
}