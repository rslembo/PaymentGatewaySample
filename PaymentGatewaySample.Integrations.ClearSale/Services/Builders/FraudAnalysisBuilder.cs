using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Integrations.ClearSale.Contracts;
using System.Linq;

namespace PaymentGatewaySample.Integrations.ClearSale.Services.Builders
{
    public static class FraudAnalysisBuilder
    {
        public static FraudAnalysisDto BuildFromClearSaleResponse(ClearSaleResponse response)
        {
            return new FraudAnalysisDto
            {
                ProviderId = response.TransactionId,
                Status = response.Orders.First().Status,
                Score = response.Orders.First().Score
            };
        }
    }
}