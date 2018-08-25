using PaymentGatewaySample.Domain.Dtos;

namespace PaymentGatewaySample.Domain.Services
{
    public interface IAcquirerService
    {
        void ProcessSale(TransactionDto transactionDto);
    }
}