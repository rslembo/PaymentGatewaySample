using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PaymentGatewaySample.Integrations.Cielo.Contracts;
using PaymentGatewaySample.Integrations.Cielo.Contracts.Models;
using PaymentGatewaySample.Integrations.Cielo.Services.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Cielo.Services
{
    public class CieloApiClient : ICieloApiClient
    {
        public IConfiguration Configuration { get; }

        public CieloApiClient(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<CieloResponse> PostSaleTransactionAsync(CieloRequest request, CieloMerchantCredential credential)
        {
            var cieloSaleUrl = Configuration.GetSection("Endpoints")["CieloApiUrl"];

            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("MerchantId", credential.MerchantId.ToString());
                client.DefaultRequestHeaders.Add("MerchantKey", credential.MerchantKey.ToString());

                var httpResponseMessage = await client.PostAsync(cieloSaleUrl + "1/sales/", httpContent);
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CieloResponse>(content);
            }
        }
    }
}