using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Domain.Services.Factories;
using PaymentGatewaySample.Services.ExtensionMethods;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class SaleProcessor : ISaleProcessor
    {
        public IMerchantConfigurationAcquirerFinder MerchantConfigurationAcquirerFinder { get; }
        public IAcquirerServiceFactory AcquirerServiceFactory { get; }
        public ITransactionCreator TransactionService { get; }

        public SaleProcessor(IMerchantConfigurationAcquirerFinder merchantConfigurationAcquirerFinder, 
            IAcquirerServiceFactory acquirerServiceFactory, ITransactionCreator transactionService)
        {
            MerchantConfigurationAcquirerFinder = merchantConfigurationAcquirerFinder ?? throw new ArgumentNullException(nameof(merchantConfigurationAcquirerFinder));
            AcquirerServiceFactory = acquirerServiceFactory ?? throw new ArgumentNullException(nameof(acquirerServiceFactory));
            TransactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        public async Task<TransactionDto> Process(TransactionDto transactionDto)
        {
            var acquirer = await MerchantConfigurationAcquirerFinder.GetAcquirerByTransaction(transactionDto);

            transactionDto = await AcquirerServiceFactory.CreateService(acquirer).ProcessSaleAsync(transactionDto);

            var transaction = transactionDto.ConvertToTransaction();
            await TransactionService.InsertAsync(transaction);

            transactionDto.Id = transaction.Id;
            transactionDto.CreatedDate = transaction.CreatedDate;

            return transactionDto;
        }
    }
}