using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class TransactionCreator : ITransactionCreator
    {
        public ITransactionRepository TransactionRepository { get; }

        public TransactionCreator(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task InsertAsync(Transaction transaction)
        {
            await TransactionRepository.InsertAsync(transaction);
        }
    }
}
