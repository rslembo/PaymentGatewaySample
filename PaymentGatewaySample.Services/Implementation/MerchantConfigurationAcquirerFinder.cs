using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class MerchantConfigurationAcquirerFinder : IMerchantConfigurationAcquirerFinder
    {
        public IMerchantFinder MerchantFinder { get; }

        public MerchantConfigurationAcquirerFinder(IMerchantFinder merchantFinder)
        {
            MerchantFinder = merchantFinder ?? throw new ArgumentNullException(nameof(merchantFinder));
        }

        public async Task<Acquirer> GetAcquirerByTransaction(TransactionDto transactionDto)
        {
            var paymentBrand = transactionDto.Payment.CreditCard.Brand;

            var merchant = await MerchantFinder.FindByIdAsync(transactionDto.MerchantId.Value);

            var acquirer = merchant.PaymentConfigurations.Where(x => x.Brand == paymentBrand).Select(x => x.Acquirer).Single();
            return acquirer;
        }
    }
}