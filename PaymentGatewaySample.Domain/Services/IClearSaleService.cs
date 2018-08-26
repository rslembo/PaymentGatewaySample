using PaymentGatewaySample.Domain.Dtos;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface IClearSaleService
    {
        Task<FraudAnalysisDto> Process(TransactionDto transactionDto);
    }
}