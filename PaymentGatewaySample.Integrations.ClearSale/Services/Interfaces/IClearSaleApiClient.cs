using PaymentGatewaySample.Integrations.ClearSale.Contracts;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.ClearSale.Services.Interfaces
{
    public interface IClearSaleApiClient
    {
        Task<AuthResponse> AuthorizeAsync(AuthRequest authRequest);
        Task<ClearSaleResponse> AnalyzeAsync(ClearSaleRequest request);
    }
}