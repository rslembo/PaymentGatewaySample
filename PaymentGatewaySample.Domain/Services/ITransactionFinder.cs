using PaymentGatewaySample.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface ITransactionFinder
    {
        Task<IEnumerable<TransactionDto>> FindAllByMerchantIdAsync(Guid merchantId);
        Task<TransactionDto> FindByIdAndMerchantIdAsync(Guid id, Guid merchantId);
    }
}