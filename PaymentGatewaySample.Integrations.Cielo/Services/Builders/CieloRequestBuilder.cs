using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Integrations.Cielo.Contracts;
using PaymentGatewaySample.Integrations.Cielo.Contracts.Models;

namespace PaymentGatewaySample.Integrations.Cielo.Services.Builders
{
    public static class CieloRequestBuilder
    {
        public static CieloRequest BuildRequestFromTransactionDto(TransactionDto transactionDto)
        {
            return new CieloRequest
            {
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Payment = new Payment
                {
                    Type = PaymentType.CreditCard,
                    Amount = transactionDto.Payment.Amount.Value,
                    Capture = true,
                    SoftDescriptor = transactionDto.Payment.SoftDescriptor,
                    Currency = transactionDto.Payment.Currency,
                    Installments = transactionDto.Payment.Installments,
                    CreditCard = new CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        Brand = transactionDto.Payment.CreditCard.Brand,
                        ExpirationDate = $"{transactionDto.Payment.CreditCard.ExpirationMonth}/{transactionDto.Payment.CreditCard.ExpirationYear}",
                        Holder = transactionDto.Payment.CreditCard.Holder,
                        SecurityCode = transactionDto.Payment.CreditCard.SecurityCode
                    }
                }
            };
        }
    }
}