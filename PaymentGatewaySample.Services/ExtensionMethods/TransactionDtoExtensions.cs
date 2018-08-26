using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Services.ExtensionMethods
{
    public static class TransactionDtoExtensions
    {
        //TODO: AutoMapper
        public static SaleResponse ConvertToSaleResponse(this TransactionDto transactionDto)
        {
            return new SaleResponse
            {
                Id = transactionDto.Id,
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Status = transactionDto.Status,
                Payment = new Domain.Contracts.Models.Payment
                {
                    Amount = transactionDto.Payment.Amount,
                    Type = transactionDto.Payment.Type,
                    CreditCard = new Domain.Contracts.Models.CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        ExpirationMonth = transactionDto.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transactionDto.Payment.CreditCard.ExpirationYear,
                        Brand = transactionDto.Payment.CreditCard.Brand
                    }
                },
                ProofOfSale = transactionDto.ProofOfSale,
                AcquirerTransactionKey = transactionDto.AcquirerTransactionKey,
                AuthorizationCode = transactionDto.AuthorizationCode,
                AcquirerTransactionId = transactionDto.AcquirerTransactionId,
                ReturnCode = transactionDto.ReturnCode,
                ReturnMessage = transactionDto.ReturnMessage,
                CreatedDate = transactionDto.CreatedDate
            };
        }

        //TODO: AutoMapper
        public static Transaction ConvertToTransaction(this TransactionDto transactionDto)
        {
            return new Transaction
            {
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Status = transactionDto.Status,
                Payment = new Domain.Entities.Payment
                {
                    Amount = transactionDto.Payment.Amount.Value,
                    CreditCard = new Domain.Entities.CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        ExpirationMonth = transactionDto.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transactionDto.Payment.CreditCard.ExpirationYear,
                        Brand = transactionDto.Payment.CreditCard.Brand
                    },
                    Type = PaymentType.CreditCard
                },
                Merchant = new Merchant
                {
                    Id = transactionDto.MerchantId.Value
                },
                ProofOfSale = transactionDto.ProofOfSale,
                AcquirerTransactionKey = transactionDto.AcquirerTransactionKey,
                AuthorizationCode = transactionDto.AuthorizationCode,
                AcquirerTransactionId = transactionDto.AcquirerTransactionId,
                ReturnCode = transactionDto.ReturnCode,
                ReturnMessage = transactionDto.ReturnMessage
            };
        }
    }
}