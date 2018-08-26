using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        public ITransactionRepository TransactionRepository { get; }

        public TransactionService(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task InsertAsync(Transaction transaction)
        {
            await TransactionRepository.InsertAsync(transaction);
        }

        //public async Task<IEnumerable<Transaction>> FindByMerchantIdAsync(Guid id)
        //{
        //    return await TransactionRepository.FindByMerchantIdAsync(id);
        //}

        //public async Task<Transaction> FindByIdAsync(Guid id)
        //{
        //    return await TransactionRepository.FindByIdAsync(id);
        //}
    }
}
