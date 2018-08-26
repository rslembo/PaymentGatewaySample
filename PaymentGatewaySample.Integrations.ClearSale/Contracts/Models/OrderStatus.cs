using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Integrations.ClearSale.Enums;

namespace PaymentGatewaySample.Integrations.ClearSale.Contracts.Models
{
    public class OrderStatus
    {
        public string Id { get; set; }
        public FraudAnalysisStatus Status { get; set; }
        public decimal Score { get; set; }
    }
}
