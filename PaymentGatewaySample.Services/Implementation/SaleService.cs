using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class SaleService : ISaleService
    {
        public IMerchantRepository MerchantRepository { get; }
        public ITransactionRepository TransactionRepository { get; }

        public SaleService(IMerchantRepository merchantRepository, ITransactionRepository transactionRepository)
        {
            MerchantRepository = merchantRepository;
            TransactionRepository = transactionRepository;
        }

        public async Task Process(SaleRequest request)
        {
            try
            {
                var merchants = await MerchantRepository.FindAllAsync();

                var transaction = ConvertTransactionFromSaleRequest(request);
                await TransactionRepository.InsertAsync(transaction);

                var transactions = await TransactionRepository.FindByMerchantIdAsync(Guid.Parse("881443DF-B87D-496F-A79A-A7D43A580BEE"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            throw new NotImplementedException();
        }

        private Transaction ConvertTransactionFromSaleRequest(SaleRequest request)
        {
            return new Transaction
            {
                RequestId = request.RequestId,
                MerchantOrderId = request.MerchantOrderId,
                Payment = new Payment
                {
                    Amount = request.Payment.Amount.Value,
                    CreditCard = new CreditCard
                    {
                        Number = request.Payment.CreditCard.Number,
                        ExpirationMonth = request.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = request.Payment.CreditCard.ExpirationYear,
                        Brand = request.Payment.CreditCard.Brand
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