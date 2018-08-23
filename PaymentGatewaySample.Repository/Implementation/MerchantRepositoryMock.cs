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
                        Id = new Guid("408E5197-D468-45A9-B0B2-B0B513481D3A"),
                        Key = "68257879AA3D8F70F2391AB9F0A5C94FF7AE7544",
                        BillingName = "ABC Store",
                        PaymentConfigurations = new List<MerchantPaymentConfiguration>
                        {
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("408E5197-D468-45A9-B0B2-B0B513481D3A"),
                                Brand = CardBrand.Master,
                                Acquirer = Acquirer.Cielo,
                                CreatedDate = DateTime.Now
                            },
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("408E5197-D468-45A9-B0B2-B0B513481D3A"),
                                Brand = CardBrand.Visa,
                                Acquirer = Acquirer.Stone,
                                CreatedDate = DateTime.Now
                            }
                        },
                        AntifraudConfiguration = new MerchantAntifraudConfiguration
                        {
                            Id = Guid.NewGuid(),
                            MerchantId = new Guid("408E5197-D468-45A9-B0B2-B0B513481D3A"),
                            Provider = AntifraudProvider.ClearSale,
                            IsEnabled = true,
                            ClientId = "0e5639c2742263323d4274b35b5bf305b8816df4",
                            ClientSecret = "aa92511f5c8c7d907ea9af66b07c81f3863058ef",
                            CreatedDate = DateTime.Now
                        },
                        CreatedDate = DateTime.Now
                    },
                    new Merchant
                    {
                        Id = new Guid("881443DF-B87D-496F-A79A-A7D43A580BEE"),
                        Key = "1110448DBFC8F697B6FFB534A265178174888666",
                        BillingName = "Store XPTO",
                        PaymentConfigurations = new List<MerchantPaymentConfiguration>
                        {
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("881443DF-B87D-496F-A79A-A7D43A580BEE"),
                                Brand = CardBrand.Master,
                                Acquirer = Acquirer.Stone
                            },
                            new MerchantPaymentConfiguration
                            {
                                Id = Guid.NewGuid(),
                                MerchantId = new Guid("881443DF-B87D-496F-A79A-A7D43A580BEE"),
                                Brand = CardBrand.Visa,
                                Acquirer = Acquirer.Cielo
                            }
                        },
                        CreatedDate = DateTime.Now
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