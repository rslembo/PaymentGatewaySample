using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PaymentGatewaySample.Integrations.Stone.Contracts;
using PaymentGatewaySample.Integrations.Stone.Services.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Stone.Services
{
    public class StoneApiClient : IStoneApiClient
    {
        public IConfiguration Configuration { get; }

        public StoneApiClient(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<StoneResponse> PostSaleTransactionAsync(StoneRequest request, Guid merchantKey)
        {
            var stoneSaleUrl = Configuration.GetSection("Endpoints")["StoneApiUrl"];

            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("MerchantKey", merchantKey.ToString());

                var httpResponseMessage = await client.PostAsync(stoneSaleUrl + "sale/", httpContent);
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StoneResponse>(content);
            }
        }
    }
}