using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PaymentGatewaySample.Repositories.Implementation
{
    public class MerchantRepositoryMock : IMerchantRepository
    {
        public async Task<IEnumerable<Merchant>> FindAllAsync()
        {
            return await Task.Run(() => 
            {
                return new List<Merchant>
                {
                    new Merchant
                    {
                        Id = new Guid("11a87d72-5f11-4108-84cf-ef67202d361d"),
                        BillingName = "ABC Store",
                        AntifraudEnabled = true,
                        PaymentConfiguration = new List<MerchantPaymentConfiguration>
                        {
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("11a87d72-5f11-4108-84cf-ef67202d361d"),
                                Brand = CardBrand.Master,
                                Acquirer = Acquirer.Cielo
                            },
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("11a87d72-5f11-4108-84cf-ef67202d361d"),
                                Brand = CardBrand.Visa,
                                Acquirer = Acquirer.Stone
                            }
                        }
                    },
                    new Merchant
                    {
                        Id = new Guid("28257e49-f4c0-4285-b934-83968de7ab50"),
                        BillingName = "Store XPTO",
                        AntifraudEnabled = false,
                        PaymentConfiguration = new List<MerchantPaymentConfiguration>
                        {
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("28257e49-f4c0-4285-b934-83968de7ab50"),
                                Brand = CardBrand.Master,
                                Acquirer = Acquirer.Cielo
                            },
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("28257e49-f4c0-4285-b934-83968de7ab50"),
                                Brand = CardBrand.Visa,
                                Acquirer = Acquirer.Stone
                            }
                        }
                    }
                };
            });
        }

        public async Task<Merchant> FindByIdAsync(Guid id)
        {
            return (await FindAllAsync()).Where(x => x.Id == id).Single();
        }
    }
}