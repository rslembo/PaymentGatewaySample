using PaymentGatewaySample.Domain.Dtos;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface IAcquirerService
    {
        Task<TransactionDto> ProcessSaleAsync(TransactionDto transactionDto);
    }
}