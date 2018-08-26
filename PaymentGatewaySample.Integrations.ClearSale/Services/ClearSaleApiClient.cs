using PaymentGatewaySample.Integrations.ClearSale.Contracts;
using PaymentGatewaySample.Integrations.ClearSale.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.ClearSale.Services
{
    public class ClearSaleApiClient : IClearSaleApiClient
    {
        public Task<ClearSaleResponse> AnalyzeAsync(ClearSaleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> AuthorizeAsync(AuthRequest authRequest)
        {
            throw new NotImplementedException();
        }
    }
}