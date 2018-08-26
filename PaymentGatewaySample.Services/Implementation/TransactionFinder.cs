using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Services.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class TransactionFinder : ITransactionFinder
    {
        public ITransactionRepository TransactionRepository { get; }

        public TransactionFinder(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<TransactionDto>> FindAllByMerchantIdAsync(Guid merchantId)
        {
            var transactionDtos = new List<TransactionDto>();

            var transactions = await TransactionRepository.FindAllByMerchantIdAsync(merchantId);

            if (!transactions.Any())
                return null;

            foreach (var transaction in transactions)
                transactionDtos.Add(transaction.ConvertToTransactionDto());

            return transactionDtos;
        }

        public async Task<TransactionDto> FindByIdAndMerchantIdAsync(Guid id, Guid merchantId)
        {
            var transaction = await TransactionRepository.FindByIdAndMerchantIdAsync(id, merchantId);

            if (transaction == null)
                return null;

            return transaction.ConvertToTransactionDto();
        }
    }
}