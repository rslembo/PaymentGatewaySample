using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class SaleService : ISaleService
    {
        public IMerchantFinder MerchantFinder { get; }
        public ITransactionRepository TransactionRepository { get; }

        public SaleService(IMerchantFinder merchantFinder, ITransactionRepository transactionRepository)
        {
            MerchantFinder = merchantFinder;
            TransactionRepository = transactionRepository;
        }

        public async Task Process(TransactionDto transactionDto)
        {
            try
            {
                var merchants = await MerchantFinder.FindAllAsync();

                var transaction = ConvertTransactionFromTransactionDto(transactionDto);
                await TransactionRepository.InsertAsync(transaction);

                var transactions = await TransactionRepository.FindByMerchantIdAsync(Guid.Parse("881443DF-B87D-496F-A79A-A7D43A580BEE"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
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