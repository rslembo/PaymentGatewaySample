using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Integrations.Stone.Contracts;
using PaymentGatewaySample.Integrations.Stone.Contracts.Models;
using PaymentGatewaySample.Integrations.Stone.ExtensionMethods;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.Stone.Services.Builders
{
    public static class StoneRequestBuilder
    {
        public static StoneRequest BuildRequestFromTransactionDto(TransactionDto transactionDto)
        {
            return new StoneRequest
            {
                CreditCardTransactionCollection = new List<CreditCardTransaction>
                {
                    new CreditCardTransaction
                    {
                        AmountInCents = transactionDto.Payment.Amount.Value,
                        CreditCardBrand = transactionDto.Payment.CreditCard.Brand.ToStoneCardBrand(),
                        CreditCardNumber = transactionDto.Payment.CreditCard.Number,
                        ExpMonth = int.Parse(transactionDto.Payment.CreditCard.ExpirationMonth),
                        ExpYear = int.Parse(transactionDto.Payment.CreditCard.ExpirationYear
                            .Substring(transactionDto.Payment.CreditCard.ExpirationYear.Length - 2)),
                        SecurityCode = int.Parse(transactionDto.Payment.CreditCard.SecurityCode),
                        HolderName = transactionDto.Payment.CreditCard.Holder,
                        InstallmentCount = transactionDto.Payment.Installments
                    }
                },
                Order = new Order
                {
                    OrderReference = transactionDto.MerchantOrderId
                }
            };
        }
    }
}