using PaymentGatewaySample.Integrations.ClearSale.Enums;
using System;

namespace PaymentGatewaySample.Integrations.ClearSale.Contracts.Models
{
    public class Payment
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public PaymentType Type { get; set; }
        public int QtyInstallments { get; set; }
        public string CardNumber { get; set; }
        public string CardBin { get; set; }
        public string CardEndNumber { get; set; }
        public CardType CardType { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardHolderName { get; set; }
        public string Address { get; set; }
        public string Nsu { get; set; }
        public CurrencyCode Currency { get; set; }
    }
}