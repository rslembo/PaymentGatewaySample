using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Dtos;

namespace PaymentGatewaySample.Services.ExtensionMethods
{
    public static class SaleRequestExtensions
    {
        //TODO: AutoMapper
        public static TransactionDto ConvertToTransactionDto(this SaleRequest saleRequest)
        {
            return new TransactionDto
            {
                RequestId = saleRequest.RequestId,
                MerchantOrderId = saleRequest.MerchantOrderId,
                Payment = new PaymentDto
                {
                    Amount = saleRequest.Payment.Amount.Value,
                    CreditCard = new CreditCardDto
                    {
                        Number = saleRequest.Payment.CreditCard.Number,
                        ExpirationMonth = saleRequest.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = saleRequest.Payment.CreditCard.ExpirationYear,
                        Brand = saleRequest.Payment.CreditCard.Brand,
                        Holder = saleRequest.Payment.CreditCard.Holder,
                        SecurityCode = saleRequest.Payment.CreditCard.SecurityCode
                    },
                    Type = Domain.Enums.PaymentType.CreditCard,
                    Currency = saleRequest.Payment.Currency,
                    Installments = saleRequest.Payment.Installments,
                    SoftDescriptor = saleRequest.Payment.SoftDescriptor
                },
                Status = Domain.Enums.TransactionStatus.Captured,
            };
        }
    }
}