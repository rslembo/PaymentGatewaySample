using PaymentGatewaySample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task InsertAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> FindAllByMerchantIdAsync(Guid merchantId);
        Task<Transaction> FindByIdAndMerchantIdAsync(Guid id, Guid merchantId);
    }
}