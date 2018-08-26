using Microsoft.EntityFrameworkCore;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Repositories.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        public ApplicationDbContext DbContext { get; }

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task InsertAsync(Transaction transaction)
        {
            await DbContext.Transactions.AddAsync(transaction);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> FindAllByMerchantIdAsync(Guid merchantId)
        {
            return await DbContext.Transactions.Where(x => x.Merchant.Id == merchantId).ToListAsync();
        }

        public async Task<Transaction> FindByIdAndMerchantIdAsync(Guid id, Guid merchantId)
        {
            return await DbContext.Transactions.Where(x => x.Id == id && x.Merchant.Id == merchantId).SingleOrDefaultAsync();
        }
    }
}