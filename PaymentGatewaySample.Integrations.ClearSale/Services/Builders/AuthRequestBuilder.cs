using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Integrations.ClearSale.Contracts;
using PaymentGatewaySample.Integrations.ClearSale.Contracts.Models;

namespace PaymentGatewaySample.Integrations.ClearSale.Services.Builders
{
    public static class AuthRequestBuilder
    {
        public static AuthRequest BuildRequestFromAntifraudConfiguration(
            MerchantAntifraudConfiguration configuration)
        {
            return new AuthRequest
            {
                Login = new Login
                {
                    ClientID = configuration.ClientId,
                    ClientSecret = configuration.ClientSecret
                }
            };
        }
    }
}