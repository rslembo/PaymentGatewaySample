using PaymentGatewaySample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task InsertAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> FindByMerchantIdAsync(Guid id);
        Task<Transaction> FindByIdAsync(Guid id);
    }
}