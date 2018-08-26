using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Integrations.Stone.Enums;

namespace PaymentGatewaySample.Integrations.Stone.ExtensionMethods
{
    public static class CardBrandExtension
    {
        public static CreditCardBrand ToStoneCardBrand(this CardBrand cardBrand)
        {
            switch (cardBrand)
            {
                case CardBrand.Master:
                    return CreditCardBrand.Mastercard;
                case CardBrand.Visa:
                    return CreditCardBrand.Visa;
                case CardBrand.Elo:
                    return CreditCardBrand.Elo;
                case CardBrand.Hipercard:
                    return CreditCardBrand.Hipercard;
                default:
                    return CreditCardBrand.Undefined;
            }
        }
    }
}