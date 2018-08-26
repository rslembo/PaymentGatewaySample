using PaymentGatewaySample.Domain.Dtos;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface ISaleService
    {
        Task<TransactionDto> Process(TransactionDto transactionDto);
    }
}