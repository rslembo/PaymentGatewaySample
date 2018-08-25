using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Enums;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface IMerchantConfigurationAcquirerFinder
    {
        Task<Acquirer> GetAcquirerByTransaction(TransactionDto transactionDto);
    }
}