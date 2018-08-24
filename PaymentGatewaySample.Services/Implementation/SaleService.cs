﻿using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class SaleService : ISaleService
    {
        public IMerchantRepository MerchantRepository { get; }

        public SaleService(IMerchantRepository merchantRepository)
        {
            MerchantRepository = merchantRepository;
        }

        public async Task Process()
        {
            var merchants = await MerchantRepository.FindAllAsync();

            throw new NotImplementedException();
        }
    }
}