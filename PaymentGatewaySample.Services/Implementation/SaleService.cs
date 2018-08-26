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
        public ITransactionService TransactionService { get; }

        public SaleService(IMerchantConfigurationAcquirerFinder merchantConfigurationAcquirerFinder, 
            IAcquirerServiceFactory acquirerServiceFactory, ITransactionService transactionService)
        {
            MerchantConfigurationAcquirerFinder = merchantConfigurationAcquirerFinder ?? throw new ArgumentNullException(nameof(merchantConfigurationAcquirerFinder));
            AcquirerServiceFactory = acquirerServiceFactory ?? throw new ArgumentNullException(nameof(acquirerServiceFactory));
            TransactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        public async Task<TransactionDto> Process(TransactionDto transactionDto)
        {
            var acquirer = await MerchantConfigurationAcquirerFinder.GetAcquirerByTransaction(transactionDto);
            acquirer = Domain.Enums.Acquirer.Cielo;

            transactionDto = await AcquirerServiceFactory.CreateService(acquirer).ProcessSaleAsync(transactionDto);

            var transaction = ConvertTransactionFromTransactionDto(transactionDto);
            await TransactionService.InsertAsync(transaction);

            transactionDto.Id = transaction.Id;
            transactionDto.CreatedDate = transaction.CreatedDate;

            return transactionDto;
        }

        private Transaction ConvertTransactionFromTransactionDto(TransactionDto transactionDto)
        {
            return new Transaction
            {
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Status = transactionDto.Status,
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
                Merchant = new Merchant
                {
                    Id = transactionDto.MerchantId.Value
                },
                ProofOfSale = transactionDto.ProofOfSale,
                AcquirerTransactionKey = transactionDto.AcquirerTransactionKey,
                AuthorizationCode = transactionDto.AuthorizationCode,
                AcquirerTransactionId = transactionDto.AcquirerTransactionId,
                ReturnCode = transactionDto.ReturnCode,
                ReturnMessage = transactionDto.ReturnMessage
            };
        }
    }
}