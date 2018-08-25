using PaymentGatewaySample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface IMerchantFinder
    {
        Task<IEnumerable<Merchant>> FindAllAsync();
        Task<Merchant> FindByIdAsync(Guid id);
    }
}