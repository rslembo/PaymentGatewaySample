using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class TransactionFinder : ITransactionFinder
    {
        public ITransactionRepository TransactionRepository { get; }

        public TransactionFinder(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<TransactionDto> FindByIdAndMerchantIdAsync(Guid id, Guid merchantId)
        {
            var transaction = await TransactionRepository.FindByIdAndMerchantIdAsync(id, merchantId);

            if (transaction == null)
                return null;

            return ConvertTransactionDtoFromTransaction(transaction);
        }

        private TransactionDto ConvertTransactionDtoFromTransaction(Transaction transaction)
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
