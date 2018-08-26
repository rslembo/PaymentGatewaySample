using PaymentGatewaySample.Integrations.Stone.Contracts;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Stone.Services.Interfaces
{
    public interface IStoneApiClient
    {
        Task<StoneResponse> PostSaleTransactionAsync(StoneRequest request, Guid merchantKey);
    }
}