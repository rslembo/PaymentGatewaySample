using PaymentGatewaySample.Domain.Dtos;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface ISaleProcessor
    {
        Task<TransactionDto> Process(TransactionDto transactionDto);
    }
}