using PaymentGatewaySample.Integrations.Cielo.Contracts;
using PaymentGatewaySample.Integrations.Cielo.Contracts.Models;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Cielo.Services.Interfaces
{
    public interface ICieloApiClient
    {
        Task<CieloResponse> PostSaleTransactionAsync(CieloRequest request, CieloMerchantCredential credential);
    }
}