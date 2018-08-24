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
    public class MerchantRepository : IMerchantRepository
    {
        public ApplicationDbContext DbContext { get; }

        public MerchantRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Merchant>> FindAllAsync()
        {
            return await DbContext.Merchants.ToListAsync();
        }

        public async Task<Merchant> FindByIdAsync(Guid id)
        {
            return await DbContext.Merchants.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}