using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Services.ExtensionMethods
{
    public static class TransactionExtensions
    {
        //TODO: AutoMapper
        public static TransactionDto ConvertToTransactionDto(this Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                RequestId = transaction.RequestId,
                MerchantOrderId = transaction.MerchantOrderId,
                Payment = new PaymentDto
                {
                    Amount = transaction.Payment.Amount,
                    CreditCard = new CreditCardDto
                    {
                        Number = transaction.Payment.CreditCard.Number,
                        ExpirationMonth = transaction.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transaction.Payment.CreditCard.ExpirationYear,
                        Brand = transaction.Payment.CreditCard.Brand
                    },
                    Type = Domain.Enums.PaymentType.CreditCard
                },
                Status = Domain.Enums.TransactionStatus.Captured,
                ProofOfSale = transaction.ProofOfSale,
                AcquirerTransactionKey = transaction.AcquirerTransactionKey,
                AuthorizationCode = transaction.AuthorizationCode,
                AcquirerTransactionId = transaction.AcquirerTransactionId,
                ReturnCode = transaction.ReturnCode,
                ReturnMessage = transaction.ReturnMessage,
                CreatedDate = transaction.CreatedDate
            };
        }
    }
}