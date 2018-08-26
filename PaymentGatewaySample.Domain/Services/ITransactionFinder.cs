using PaymentGatewaySample.Domain.Dtos;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface ITransactionFinder
    {
        Task<TransactionDto> FindByIdAndMerchantIdAsync(Guid id, Guid merchantId);
    }
}