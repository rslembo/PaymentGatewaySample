using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Integrations.ClearSale.Enums;

namespace PaymentGatewaySample.Integrations.Stone.ExtensionMethods
{
    public static class CardBrandExtension
    {
        public static CardType ToClearSaleCardBrand(this CardBrand cardBrand)
        {
            switch (cardBrand)
            {
                case CardBrand.Master:
                    return CardType.MasterCard;
                case CardBrand.Visa:
                    return CardType.Visa;
                case CardBrand.Amex:
                    return CardType.AmericanExpress;
                case CardBrand.Aura:
                    return CardType.Aura;
                case CardBrand.Diners:
                    return CardType.Diners;
                case CardBrand.Hipercard:
                    return CardType.HiperCard;
                default:
                    return CardType.Others;
            }
        }
    }
}