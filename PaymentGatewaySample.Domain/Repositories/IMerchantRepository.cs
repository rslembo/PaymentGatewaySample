using PaymentGatewaySample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Repositories
{
    public interface IMerchantRepository
    {
        Task<IEnumerable<Merchant>> FindAllAsync();
        Task<Merchant> FindByIdAsync(Guid id);
    }
}