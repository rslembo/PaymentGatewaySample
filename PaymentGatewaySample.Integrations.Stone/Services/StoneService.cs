using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Services;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Stone.Services
{
    public class StoneService : IStoneService
    {
        public Task<TransactionDto> ProcessSaleAsync(TransactionDto transactionDto)
        {
            throw new System.NotImplementedException();
        }
    }
}