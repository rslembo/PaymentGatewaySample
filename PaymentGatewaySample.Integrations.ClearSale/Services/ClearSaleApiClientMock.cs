using Microsoft.Extensions.Configuration;
using PaymentGatewaySample.Integrations.ClearSale.Contracts;
using PaymentGatewaySample.Integrations.ClearSale.Contracts.Models;
using PaymentGatewaySample.Integrations.ClearSale.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.ClearSale.Services
{
    public class ClearSaleApiClientMock : IClearSaleApiClient
    {
        public IConfiguration Configuration { get; }

        public ClearSaleApiClientMock(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<AuthResponse> AuthorizeAsync(AuthRequest authRequest)
        {
            return await Task.Run(() =>
            {
                authRequest.Login.Apikey = Configuration.GetSection("Settings")["ClearSaleApiKey"];

                return new AuthResponse
                {
                    Token = new AuthToken
                    {
                        
                        Value = "BA7D2CA4581B12D2398D069449F8794EAC798C6C",
                        ExpirationDate = DateTime.Now.AddHours(1).ToString()
                    }
                };
            });
        }

        public async Task<ClearSaleResponse> AnalyzeAsync(ClearSaleRequest request)
        {
            return await Task.Run(() =>
            {
                var isFraud = request.Orders.First().Payments.First().CardHolderName.Equals("ClearSale Fraud");

                return new ClearSaleResponse
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    Orders = new List<OrderStatus>
                    {
                        new OrderStatus
                        {
                            Id = Guid.NewGuid().ToString(),
                            Status = isFraud ? Domain.Enums.FraudAnalysisStatus.FRD : Domain.Enums.FraudAnalysisStatus.APA,
                            Score = isFraud ? 98.05m : 05.00m
                        }
                    }
                };
            });
        }
    }
}