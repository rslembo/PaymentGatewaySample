using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class MerchantFinder : IMerchantFinder
    {
        public IMerchantRepository MerchantRepository { get; }

        public MerchantFinder(IMerchantRepository merchantRepository)
        {
            MerchantRepository = merchantRepository ?? throw new ArgumentNullException(nameof(merchantRepository));
        }

        public async Task<IEnumerable<Merchant>> FindAllAsync()
        {
            return await MerchantRepository.FindAllAsync();
        }

        public async Task<Merchant> FindByIdAsync(Guid id)
        {
            return await MerchantRepository.FindByIdAsync(id);
        }
    }
}