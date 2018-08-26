using Microsoft.Extensions.Configuration;
using PaymentGatewaySample.Integrations.Cielo.Contracts;
using PaymentGatewaySample.Integrations.Cielo.Contracts.Models;
using PaymentGatewaySample.Integrations.Cielo.Enums;
using PaymentGatewaySample.Integrations.Cielo.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Cielo.Services
{
    public class CieloApiClientMock : ICieloApiClient
    {
        public IConfiguration Configuration { get; }

        public CieloApiClientMock(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<CieloResponse> PostSaleTransactionAsync(CieloRequest request, CieloMerchantCredential credential)
        {
            return await Task.Run(() => 
            {
                var response = new CieloResponse
                {
                    ProofOfSale = "123",
                    Tid = "123456",
                    AuthorizationCode = "123456",
                    PaymentId = Guid.NewGuid()
                };

                if (request.Payment.CreditCard.Holder.Equals("Cielo Error"))
                {
                    response.Status = CieloStatus.Aborted;
                    response.ReturnCode = "70";
                    response.ReturnMessage = "Problemas com o Cartão de Crédito";
                    return response;
                }

                response.Status = CieloStatus.PaymentConfirmed;
                response.ReturnCode = "4";
                response.ReturnMessage = "Operação realizada com sucesso";
                return response;
            });
        }
    }
}