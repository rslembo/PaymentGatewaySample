using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Domain.Services.Factories;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class SaleService : ISaleService
    {
        public IMerchantConfigurationAcquirerFinder MerchantConfigurationAcquirerFinder { get; }
        public IAcquirerServiceFactory AcquirerServiceFactory { get; }

        public SaleService(
            IMerchantConfigurationAcquirerFinder merchantConfigurationAcquirerFinder, 
            IAcquirerServiceFactory acquirerServiceFactory)
        {
            MerchantConfigurationAcquirerFinder = merchantConfigurationAcquirerFinder ?? throw new ArgumentNullException(nameof(merchantConfigurationAcquirerFinder));
            AcquirerServiceFactory = acquirerServiceFactory ?? throw new ArgumentNullException(nameof(acquirerServiceFactory));
        }

        public async Task Process(TransactionDto transactionDto)
        {
            var acquirer = await MerchantConfigurationAcquirerFinder.GetAcquirerByTransaction(transactionDto);
            acquirer = Domain.Enums.Acquirer.Cielo;

            AcquirerServiceFactory.CreateService(acquirer).ProcessSale(transactionDto);
        }

        private Transaction ConvertTransactionFromTransactionDto(TransactionDto transactionDto)
        {
            return new Transaction
            {
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Payment = new Payment
                {
                    Amount = transactionDto.Payment.Amount.Value,
                    CreditCard = new CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        ExpirationMonth = transactionDto.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transactionDto.Payment.CreditCard.ExpirationYear,
                        Brand = transactionDto.Payment.CreditCard.Brand
                    },
                    Type = Domain.Enums.PaymentType.CreditCard
                },
                Status = Domain.Enums.TransactionStatus.Captured,
                Merchant = new Merchant
                {
                    Id = Guid.Parse("881443DF-B87D-496F-A79A-A7D43A580BEE")
                }
            };
        }
    }
}